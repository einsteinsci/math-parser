using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[Token("number", 5)]
	public sealed class TokenNumber : TokenLiteral
	{
		public override bool SingleChar
		{
			get { return false; }
		}

		public override bool Matches(Token prev, string lexeme)
		{
			foreach (Token t in TokenRegistry.Tokens)
			{
				if (t.Type == TokenType.Operator && t.Matches(prev, lexeme))
				{
					return false;
				}
			}

			if (!lexeme[0].IsNumeric() && lexeme[0] != '.')
			{
				return false;
			}

			double res;
			return double.TryParse(lexeme, out res);
		}

		public override string ToString()
		{
			return "[Number]";
		}
	}
}
