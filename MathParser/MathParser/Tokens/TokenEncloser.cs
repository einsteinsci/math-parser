using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	public enum EncloserSide
	{
		Opening,
		Closing
	}

	public abstract class TokenEncloser : Token
	{
		public const int PRIORITY = 3;

		public abstract EncloserSide Side
		{ get; protected set; }

		public abstract string EncloserName
		{ get; }

		public abstract string Opener
		{ get; }

		public abstract string Closer
		{ get; }

		public override bool SingleChar
		{ get { return true; } }

		public override TokenType Type
		{ get { return TokenType.Encloser; } }

		public override bool Matches(Token previous, string lexeme)
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
				throw new ArgumentOutOfRangeException("this.Side", 
					"Side is an invalid EncloserSide.");
			}
		}
	}
}
