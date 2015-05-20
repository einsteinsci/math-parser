using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Tokens;

namespace MathParser.Lexing
{
	public class Lexer
	{
		public static Lexer Instance
		{ get; private set; }

		public string Expression
		{ get; set; }

		public LexStream Lexed
		{ get; set; }

		static Lexer()
		{
			Instance = new Lexer();
		}

		public void Lex()
		{
			Lexed = new LexStream();

			List<Token> canMatch = new List<Token>();
			List<Token> doesMatch = new List<Token>();

			for (int i = 0; i < Expression.Length; i++)
			{
				char current = Expression[i];
				char? next = i + 1 < Expression.Length ? (char?)Expression[i + 1] : null;


			}
		}

		internal bool ShouldEndToken()
		{
			return false;
		}

		public static LexStream Lex(string expression)
		{
			Instance.Expression = expression;
			Instance.Lex();
			return Instance.Lexed;
		}
	}
}
