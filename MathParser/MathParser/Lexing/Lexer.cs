using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.Tokens;

namespace MathParser.Lexing
{
    public sealed class Lexer
    {
		public static readonly Lexer Instance = new Lexer();

		public string Expression
		{ get; set; }

		public List<Lexeme> Lexed
		{ get; private set; }

		public void Lex()
		{
			if (Expression == null)
			{
				return;
			}

			string lexeme = "";

			for (int index = 0; index < Expression.Length; index++)
			{
				bool done = false;
				char c = Expression[index];

				List<Token> currentValid = ValidTokens(lexeme);
				List<Token> nextValid = ValidTokens(lexeme + c);

				if (nextValid.Count() == 0)
				{
					// OVER HERE
				}

				if (!c.IsWhitespace())
				{
					done = true;
				}
			}
		}

		public static List<Token> ValidTokens(string lexeme)
		{
			List<Token> res = new List<Token>();
			foreach (Token token in Token.Registry.Values)
			{
				res.Add(token);
			}

			return res;
		}

		public static List<Lexeme> Lex(string expression)
		{
			Instance.Lexed = new List<Lexeme>();
			Instance.Expression = expression;

			Instance.Lex();

			return Instance.Lexed;
		}
    }
}
