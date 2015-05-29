using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[MakeToken("comma")]
	public class TokenClassComma : TokenClass
	{
		public override int LexerPriority
		{ get { return TokenClassOperator.PRIORITY; } }

		public override TokenType Type
		{
			get { return TokenType.Delimiter; }
		}

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
