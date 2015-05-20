using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[MakeToken("brace", PRIORITY, Custom = true)]
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

		public override Dictionary<string, Token> CustomRegistry
		{
			get
			{
				Dictionary<string, Token> res = new Dictionary<string, Token>();
				res.Add("braceOpen", new TokenBrace(EncloserSide.Opening));
				res.Add("braceClose", new TokenBrace(EncloserSide.Closing));
				return res;
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
