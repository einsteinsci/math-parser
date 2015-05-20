using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	public static class TokenRegistry
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
			public Token Token
			{ get; private set; }

			public int Priority
			{ get; private set; }

			public string Key
			{ get; private set; }

			public RegistryItem(string key, Token token, int priority)
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

		public static List<Token> Tokens
		{
			get
			{
				List<Token> res = new List<Token>();
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

		public static Token Get(string key)
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

		public static void RegisterTokens()
		{
			if (HasRegistered)
			{
				return;
			}

			Registry = new List<RegistryItem>();

			Assembly current = Assembly.GetCallingAssembly();
			foreach (Type t in current.GetTypes())
			{
				if (!typeof(Token).IsAssignableFrom(t))
				{
					continue;
				}

				if (t.IsAbstract)
				{
					continue;
				}

				MakeTokenAttribute att = t.GetCustomAttributes<MakeTokenAttribute>().FirstOrDefault();
				if (att != null)
				{
					Token token = Activator.CreateInstance(t) as Token;
					if (att.Custom)
					{
						foreach (KeyValuePair<string, Token> kvp in token.CustomRegistry)
						{
							Register(kvp.Key, kvp.Value, att.Priority);
							Logger.Log(LogLevel.Debug, "register", 
								"Token registered: " + kvp.Key + " = " + kvp.Value.ToString());
						}
					}
					else
					{
						Register(att.TokenName, token, att.Priority);
						Logger.Log(LogLevel.Debug, "register", "Token registered: " + 
							att.TokenName + " = " + token.ToString());
					}
				}
			}

			HasRegistered = true;
		}

		public static void Register(string key, Token token, int priority)
		{
			Registry.Add(new RegistryItem(key, token, priority));
		}

		public static Dictionary<int, List<Token>> TokensByPriority()
		{
			Dictionary<int, List<Token>> res = new Dictionary<int, List<Token>>();
			foreach (RegistryItem item in Registry)
			{
				if (!res.ContainsKey(item.Priority))
				{
					res.Add(item.Priority, new List<Token>());
				}

				res[item.Priority].Add(item.Token);
			}

			return res;
		}

		public static List<Token> TokensByPriority(int priority)
		{
			return TokensByPriority()[priority];
		}

		public static int PriorityOf(Token token)
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

		public static string KeyOf(Token token)
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
