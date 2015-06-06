using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Lexing
{
	[TokenType("bracket", Custom = true)]
	public class TokenTypeBracket : TokenTypeEncloser
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

		public override Dictionary<string, TokenType> CustomRegistry
		{
			get
			{
				Dictionary<string, TokenType> res = new Dictionary<string, TokenType>();
				res.Add("bracketOpen", new TokenTypeBracket(EncloserSide.Opening));
				res.Add("bracketClose", new TokenTypeBracket(EncloserSide.Closing));
				return res;
			}
		}

		public TokenTypeBracket(EncloserSide side)
		{
			_side = side;
		}

		public TokenTypeBracket() : this(EncloserSide.Opening)
		{ }
	}
}
