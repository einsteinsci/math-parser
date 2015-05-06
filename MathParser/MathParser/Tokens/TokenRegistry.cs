using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	public static class TokenRegistry
	{
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
				return res;
			}
		}

		public static Token Get(string key)
		{
			foreach (RegistryItem ri in Registry)
			{
				if (ri.Key == key)
				{
					return ri.Token;
				}
			}

			return null;
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
	}
}
