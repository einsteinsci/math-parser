using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[TokenType("comma")]
	public class TokenTypeComma : TokenType
	{
		public override int LexerPriority
		{ get { return TokenTypeOperator.PRIORITY; } }

		public override bool Matches(string lexeme)
		{
			return lexeme == ",";
		}

		public override string ToString()
		{
			return "[Comma]";
		}
	}
}
