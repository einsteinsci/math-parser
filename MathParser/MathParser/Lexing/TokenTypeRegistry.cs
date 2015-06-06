using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Lexing
{
	public static class TokenTypeRegistry
	{
		public static bool HasRegistered
		{
			get
			{
				return _hasRegistered;
			}
			private set
			{
				_hasRegistered = value;
			}
		}
		static bool _hasRegistered = false;

		public class RegistryItem
		{
			public TokenType Token
			{ get; private set; }

			public int Priority
			{ get; private set; }

			public string Key
			{ get; private set; }

			public RegistryItem(string key, TokenType token, int priority)
			{
				Key = key;
				Token = token;
				Priority = priority;
			}

			public override string ToString()
			{
				return "[" + Key + "] [" + Priority + "] " + Token.ToString();
			}
		}

		public static List<RegistryItem> Registry
		{ get; private set; }

		public static List<TokenType> Tokens
		{
			get
			{
				List<TokenType> res = new List<TokenType>();
				foreach (RegistryItem r in Registry)
				{
					res.Add(r.Token);
				}

				res.Sort((a, b) =>
				{
					return PriorityOf(a) - PriorityOf(b);
				});

				return res;
			}
		}

		public static TokenType Get(string key)
		{
			if (Registry == null)
			{
				RegisterTokens();
			}

			foreach (RegistryItem ri in Registry)
			{
				if (ri.Key.ToLower() == key.ToLower())
				{
					return ri.Token;
				}
			}

			return null;
		}

		public static void RegisterTokens(bool force = false)
		{
			if (HasRegistered && !force)
			{
				return;
			}

			Logger.Log(LogLevel.Info, Logger.REGISTRY, "Starting token registration.");

			Registry = new List<RegistryItem>();

			foreach (Assembly assembly in Extensibility.AllAssemblies)
			{
				foreach (Type t in assembly.GetTypes())
				{
					if (!typeof(TokenType).IsAssignableFrom(t))
					{
						continue;
					}

					if (t.IsAbstract)
					{
						continue;
					}

					TokenTypeAttribute att = t.GetCustomAttributes<TokenTypeAttribute>().FirstOrDefault();
					if (att != null)
					{
						TokenType token = Activator.CreateInstance(t) as TokenType;
						int priority = token.LexerPriority;
						if (att.Custom)
						{
							foreach (KeyValuePair<string, TokenType> kvp in token.CustomRegistry)
							{
								Register(kvp.Key, kvp.Value, priority);
								Logger.Log(LogLevel.Debug, "register",
									"Token registered: " + kvp.Key + " = " + kvp.Value.ToString());
							}
						}
						else
						{
							Register(att.TokenName, token, priority);
							Logger.Log(LogLevel.Debug, "register", "Token registered: " +
								att.TokenName + " = " + token.ToString());
						}
					}
				}
			}

			HasRegistered = true;
		}

		public static void Register(string key, TokenType token, int priority)
		{
			Registry.Add(new RegistryItem(key, token, priority));
		}

		public static Dictionary<int, List<TokenType>> TokensByPriority()
		{
			Dictionary<int, List<TokenType>> res = new Dictionary<int, List<TokenType>>();
			foreach (RegistryItem item in Registry)
			{
				if (!res.ContainsKey(item.Priority))
				{
					res.Add(item.Priority, new List<TokenType>());
				}

				res[item.Priority].Add(item.Token);
			}

			return res;
		}

		public static List<TokenType> TokensByPriority(int priority)
		{
			return TokensByPriority()[priority];
		}

		public static int PriorityOf(TokenType token)
		{
			foreach (RegistryItem r in Registry)
			{
				if (r.Token == token)
				{
					return r.Priority;
				}
			}

			return -1;
		}

		public static string KeyOf(TokenType token)
		{
			foreach (RegistryItem r in Registry)
			{
				if (r.Token == token)
				{
					return r.Key;
				}
			}

			return null;
		}
	}
}
