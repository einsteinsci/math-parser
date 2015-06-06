using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Lexing
{
	[TokenType("brace", Custom = true)]
	public sealed class TokenTypeBrace : TokenTypeEncloser
	{
		public override EncloserSide Side
		{ get { return _side; } }
		private EncloserSide _side;

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

		public override Dictionary<string, TokenType> CustomRegistry
		{
			get
			{
				Dictionary<string, TokenType> res = new Dictionary<string, TokenType>();
				res.Add("braceOpen", new TokenTypeBrace(EncloserSide.Opening));
				res.Add("braceClose", new TokenTypeBrace(EncloserSide.Closing));
				return res;
			}
		}

		public TokenTypeBrace(EncloserSide side)
		{
			_side = side;
		}

		public TokenTypeBrace() : this(EncloserSide.Opening)
		{ }
	}
}
