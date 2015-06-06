using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[TokenType("parenthesis", Custom = true)]
	public sealed class TokenTypeParenthesis : TokenTypeEncloser
	{
		public override EncloserSide Side
		{ get { return _side; } }
		private EncloserSide _side;

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

		public override Dictionary<string, TokenType> CustomRegistry
		{
			get
			{
				Dictionary<string, TokenType> res = new Dictionary<string, TokenType>();
				res.Add("parenthesisOpen", new TokenTypeParenthesis(EncloserSide.Opening));
				res.Add("parenthesisClose", new TokenTypeParenthesis(EncloserSide.Closing));
				return res;
			}
		}

		public TokenTypeParenthesis(EncloserSide side)
		{
			_side = side;
		}

		public TokenTypeParenthesis() : this(EncloserSide.Opening)
		{ }
	}
}
