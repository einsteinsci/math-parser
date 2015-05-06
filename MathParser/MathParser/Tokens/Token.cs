using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace MathParser.Tokens
{
	public abstract class Token
	{
		public virtual bool IsOperator
		{
			get
			{
				return false;
			}
		}

		public abstract bool SingleChar
		{ get; }

		public abstract bool Matches(string lexeme);

		public static Token Number { get { return TokenRegistry.Get("number"); } }
		public static Token Comment { get { return TokenRegistry.Get("comment"); } }
		public static Token OperatorPlus { get { return TokenRegistry.Get("operatorPlus"); } }

		public static void RegisterTokens()
		{
			Assembly current = Assembly.GetCallingAssembly();
			foreach (Type t in current.GetTypes())
			{
				if (!typeof(Token).IsAssignableFrom(t))
				{
					continue;
				}

				TokenAttribute att = t.GetCustomAttributes<TokenAttribute>().FirstOrDefault();
				if (att != null)
				{
					Token token = Activator.CreateInstance(t) as Token;
					TokenRegistry.Register(att.TokenName, token, att.Priority);
				}
			}
		}

		public static List<Token> SingleCharTokens
		{
			get
			{
				List<Token> res = new List<Token>();
				foreach (Token t in Token.Registry.Values)
				{
					if (t.SingleChar)
					{
						res.Add(t);
					}
				}

				return res;
			}
		}

		public static List<Token> MultiCharTokens
		{
			get
			{
				List<Token> res = new List<Token>();
				foreach (Token t in Token.Registry.Values)
				{
					if (!t.SingleChar)
					{
						res.Add(t);
					}
				}

				return res;
			}
		}
	}
}
