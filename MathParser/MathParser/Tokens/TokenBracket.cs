using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[Token("bracket", PRIORITY, Custom = true)]
	public class TokenBracket : TokenEncloser
	{
		public override EncloserSide Side
		{ get; protected set; }

		public override string EncloserName
		{
			get { return "Bracket"; }
		}

		public override string Opener
		{
			get { return "["; }
		}

		public override string Closer
		{
			get { return "]"; }
		}

		public override Dictionary<string, Token> CustomRegistry
		{
			get
			{
				Dictionary<string, Token> res = new Dictionary<string, Token>();
				res.Add("bracketOpen", new TokenBracket(EncloserSide.Opening));
				res.Add("bracketClose", new TokenBracket(EncloserSide.Closing));
				return res;
			}
		}

		public TokenBracket(EncloserSide side)
		{
			Side = side;
		}

		public TokenBracket() : this(EncloserSide.Opening)
		{ }
	}
}
