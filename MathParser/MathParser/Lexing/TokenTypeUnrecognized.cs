using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Lexing
{
	[TokenType("unrecognized")]
	public sealed class TokenTypeUnrecognized : TokenType
	{
		public override int LexerPriority
		{ get { return int.MaxValue; } }

		public override bool IgnoreInTree
		{ get { return true; } }

		public override bool Matches(string lexeme)
		{
			return true;
		}

		public override string ToString()
		{
			return "[UNRECOGNIZED]";
		}
	}
}
