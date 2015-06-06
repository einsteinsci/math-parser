using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Lexing
{
	public enum EncloserSide
	{
		Opening,
		Closing
	}

	public abstract class TokenTypeEncloser : TokenType
	{
		public const int PRIORITY = 3;

		public abstract EncloserSide Side
		{ get; }

		public override int LexerPriority
		{ get { return PRIORITY; } }

		public abstract string EncloserName
		{ get; }

		public abstract string Opener
		{ get; }

		public abstract string Closer
		{ get; }

		public override bool Matches(string lexeme)
		{
			if (Side == EncloserSide.Opening)
			{
				return lexeme == Opener;
			}
			else
			{
				return lexeme == Closer;
			}
		}

		public override string ToString()
		{
			switch (Side)
			{
			case EncloserSide.Opening:
				return "[" + EncloserName + "In]";
			case EncloserSide.Closing:
				return "[" + EncloserName + "Out]";
			default:
				return "[" + EncloserName + "Invalid]";
			}
		}
	}
}
