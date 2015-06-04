using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[MakeTokenClass("bracket", Custom = true)]
	public class TokenClassBracket : TokenClassEncloser
	{
		public override EncloserSide Side
		{ get { return _side; } }
		private EncloserSide _side;

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

		public override Dictionary<string, TokenClass> CustomRegistry
		{
			get
			{
				Dictionary<string, TokenClass> res = new Dictionary<string, TokenClass>();
				res.Add("bracketOpen", new TokenClassBracket(EncloserSide.Opening));
				res.Add("bracketClose", new TokenClassBracket(EncloserSide.Closing));
				return res;
			}
		}

		public TokenClassBracket(EncloserSide side)
		{
			_side = side;
		}

		public TokenClassBracket() : this(EncloserSide.Opening)
		{ }
	}
}
