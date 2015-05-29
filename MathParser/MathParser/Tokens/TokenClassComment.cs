using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[MakeToken("comment")]
	public class TokenClassComment : TokenClass
	{
		public override int LexerPriority
		{ get { return 1; } }

		public override TokenType Type
		{
			get { return TokenType.Ignored; }
		}

		public override bool Matches(string lexeme)
		{
			return lexeme.StartsWith("/*") && lexeme.EndsWith("*/") &&
				lexeme.Length >= 4; /**/
		}

		public override string ToString()
		{
			return "[Comment]";
		}
	}
}
