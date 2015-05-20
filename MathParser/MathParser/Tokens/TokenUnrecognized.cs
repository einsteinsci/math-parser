using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[Token("unrecognized", int.MaxValue)]
	public sealed class TokenUnrecognized : Token
	{
		public override bool SingleChar
		{ get { return false; } }

		public override int LexerPriority
		{ get { return int.MaxValue; } }

		public override TokenType Type
		{ get { return TokenType.Ignored; } }

		public override bool Matches(Token prev, string lexeme)
		{
			return true;
		}

		public override string ToString()
		{
			return "[UNRECOGNIZED]";
		}
	}
}
