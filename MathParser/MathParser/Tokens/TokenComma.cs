using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[Token("comma", TokenOperator.PRIORITY)]
	public class TokenComma : Token
	{
		public override bool SingleChar
		{ get { return true; } }

		public override bool IsOperator
		{ get { return true; } }

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
