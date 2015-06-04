using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[MakeTokenClass("parenthesis", Custom = true)]
	public sealed class TokenClassParenthesis : TokenClassEncloser
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

		public override Dictionary<string, TokenClass> CustomRegistry
		{
			get
			{
				Dictionary<string, TokenClass> res = new Dictionary<string, TokenClass>();
				res.Add("parenthesisOpen", new TokenClassParenthesis(EncloserSide.Opening));
				res.Add("parenthesisClose", new TokenClassParenthesis(EncloserSide.Closing));
				return res;
			}
		}

		public TokenClassParenthesis(EncloserSide side)
		{
			_side = side;
		}

		public TokenClassParenthesis() : this(EncloserSide.Opening)
		{ }
	}
}
