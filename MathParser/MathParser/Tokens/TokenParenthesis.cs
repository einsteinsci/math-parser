using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[Token("parenthesis", PRIORITY, Custom = true)]
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

		public override List<Token> CustomRegistry
		{
			get
			{
				return new List<Token>(new Token[] { 
					new TokenParenthesis(EncloserSide.Opening), 
					new TokenParenthesis(EncloserSide.Closing) 
				});
			}
		}

		public TokenParenthesis() : this(EncloserSide.Opening)
		{ }

		public TokenParenthesis(EncloserSide side)
		{
			Side = side;
		}
	}
}
