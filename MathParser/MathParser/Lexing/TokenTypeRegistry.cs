using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Lexing
{
	/// <summary>
	/// Registry where all token types are stored, in the form of a priority list.
	/// Generally only handled internally.
	/// </summary>
	public static class TokenTypeRegistry
	{
		/// <summary>
		/// Gets whether initial registration is completed
		/// </summary>
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

		/// <summary>
		/// Class containing registered token type data
		/// </summary>
		public class RegistryItem
		{
			/// <summary>
			/// Token in datum
			/// </summary>
			public TokenType Token
			{ get; private set; }

			/// <summary>
			/// Priority of token in registry
			/// </summary>
			public int Priority
			{ get; private set; }

			/// <summary>
			/// Key used in registry
			/// </summary>
			public string Key
			{ get; private set; }

			/// <summary>
			/// Instantiates a new TokenTypeRegistry.RegistryItem
			/// </summary>
			public RegistryItem(string key, TokenType token, int priority)
			{
				Key = key;
				Token = token;
				Priority = priority;
			}

			/// <summary>
			/// Converts the datum to a string
			/// </summary>
			public override string ToString()
			{
				return "[" + Key + "] [" + Priority + "] " + Token.ToString();
			}
		}

		/// <summary>
		/// Inner list of registry items. Avoid referencing directly.
		/// </summary>
		public static List<RegistryItem> Registry
		{ get; private set; }

		/// <summary>
		/// List of all token types registered
		/// </summary>
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

		/// <summary>
		/// Gets the token type of a given key
		/// </summary>
		/// <param name="key">Key to check</param>
		/// <returns>Token type for the given key</returns>
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

		/// <summary>
		/// Does initial registration, redoing if specified
		/// </summary>
		/// <param name="force">Set to true to force re-registration.</param>
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

		/// <summary>
		/// Registers a token type with a key and priority
		/// </summary>
		/// <param name="key">Key stored in registry. Must be unique.</param>
		/// <param name="token">TokenType singleton to register</param>
		/// <param name="priority">Tokenizer priority of token type</param>
		public static void Register(string key, TokenType token, int priority)
		{
			Registry.Add(new RegistryItem(key, token, priority));
		}

		/// <summary>
		/// Dictionary of all priorities, each priority mapped to a list
		/// of all token types with that priority.
		/// </summary>
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

		/// <summary>
		/// Gets a list of all token types with a given priority.
		/// </summary>
		/// <param name="priority">Priority level to check</param>
		public static List<TokenType> TokensByPriority(int priority)
		{
			return TokensByPriority()[priority];
		}

		/// <summary>
		/// Gets the priority of a token type.
		/// </summary>
		/// <param name="token">Token type to check.</param>
		/// <returns>
		///   Priority of specified token type, -1 if token type is 
		///   not found.
		/// </returns>
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

		/// <summary>
		/// Gets the key of a token type
		/// </summary>
		/// <param name="token">Token type to check.</param>
		/// <returns>
		///   The key used to register the token type, null if no
		///   token type is found.
		/// </returns>
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
