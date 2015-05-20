using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[MakeToken("comma", TokenOperator.PRIORITY)]
	public class TokenComma : Token
	{
		public override bool SingleChar
		{ get { return true; } }

		public override int LexerPriority
		{ get { return TokenOperator.PRIORITY; } }

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
