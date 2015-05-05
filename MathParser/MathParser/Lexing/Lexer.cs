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
				char c = Expression[index];

				if (!c.IsWhitespace())
				{
					// OVER HERE
				}

				IEnumerable<Token> possibleTokens = 
					from tok in Token.Registry.Values
					where tok.Matches(lexeme)
					select tok;
			}
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
