using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[MakeToken("parenthesis", Custom = true)]
	public sealed class TokenParenthesis : TokenEncloser
	{
		public override EncloserSide Side
		{ get; protected set; }

		public override string Opener
		{
			get { return "("; }
		}

		public override string Closer
		{
			get { return ")"; }
		}

		public override string EncloserName
		{
			get { return "Parenthesis"; }
		}

		public override Dictionary<string, Token> CustomRegistry
		{
			get
			{
				Dictionary<string, Token> res = new Dictionary<string, Token>();
				res.Add("parenthesisOpen", new TokenParenthesis(EncloserSide.Opening));
				res.Add("parenthesisClose", new TokenParenthesis(EncloserSide.Closing));
				return res;
			}
		}

		public TokenParenthesis(EncloserSide side)
		{
			Side = side;
		}

		public TokenParenthesis() : this(EncloserSide.Opening)
		{ }
	}
}
