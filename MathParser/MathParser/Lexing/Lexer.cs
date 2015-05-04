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

				if (lexeme == "")
				{
					foreach (Token t in Token.SingleCharTokens)
					{

					}
				}
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
