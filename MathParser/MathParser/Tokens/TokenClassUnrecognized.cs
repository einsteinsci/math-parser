using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[MakeToken("unrecognized")]
	public sealed class TokenClassUnrecognized : TokenClass
	{
		public override int LexerPriority
		{ get { return int.MaxValue; } }

		public override TokenType Type
		{ get { return TokenType.Ignored; } }

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
