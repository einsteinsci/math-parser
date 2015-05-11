using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[Token("brace", PRIORITY, Custom = true)]
	public class TokenBrace : TokenEncloser
	{
		public override EncloserSide Side
		{ get; protected set; }

		public override string EncloserName
		{
			get { return "Brace"; }
		}

		public override string Opener
		{
			get { return "{"; }
		}

		public override string Closer
		{
			get { return "}"; }
		}

		public override List<Token> CustomRegistry
		{
			get
			{
				return new List<Token>(new Token[] {
					new TokenBrace(EncloserSide.Opening),
					new TokenBrace(EncloserSide.Closing)
				});
			}
		}

		public TokenBrace(EncloserSide side)
		{
			Side = side;
		}

		public TokenBrace() : this(EncloserSide.Opening)
		{ }
	}
}
