using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[MakeTokenClass("brace", Custom = true)]
	public class TokenClassBrace : TokenClassEncloser
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

		public override Dictionary<string, TokenClass> CustomRegistry
		{
			get
			{
				Dictionary<string, TokenClass> res = new Dictionary<string, TokenClass>();
				res.Add("braceOpen", new TokenClassBrace(EncloserSide.Opening));
				res.Add("braceClose", new TokenClassBrace(EncloserSide.Closing));
				return res;
			}
		}

		public TokenClassBrace(EncloserSide side)
		{
			Side = side;
		}

		public TokenClassBrace() : this(EncloserSide.Opening)
		{ }
	}
}
