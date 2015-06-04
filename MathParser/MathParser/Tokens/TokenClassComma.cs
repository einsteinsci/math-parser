using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[MakeTokenClass("comma")]
	public class TokenClassComma : TokenClass
	{
		public override int LexerPriority
		{ get { return TokenClassOperator.PRIORITY; } }

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
