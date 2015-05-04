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
		public static Dictionary<string, Token> Registry
		{ get; private set; }

		public abstract bool Matches(string lexeme);

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
					Token tok = Activator.CreateInstance(t) as Token;
				}
			}
		}
	}
}
