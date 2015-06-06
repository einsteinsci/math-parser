using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Lexing
{
	[TokenType("comment")]
	public class TokenTypeComment : TokenType
	{
		public override int LexerPriority
		{ get { return 1; } }

		public override bool IgnoreInTree
		{ get { return true; } }

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
