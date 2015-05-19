using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[Token("operatorNegative", PRIORITY)]
	public class TokenOperatorNegative : TokenOperator
	{
		public override string Operator
		{ get { return "-"; } }

		public override int Precedence
		{ get { return PREC_UNARY; } }

		public override bool SingleChar
		{ get { return true; } }

		public override int ArgumentCount
		{ get { return 1; } }

		public override bool Matches(Token previous, string lexeme)
		{
			if (!base.Matches(previous, lexeme))
			{
				return false;
			}

			bool minus = false;
			if (previous != null)
			{
				if (previous.Type == TokenType.Literal)
				{
					minus = true;
				}
				else if (previous.Type == TokenType.Encloser)
				{
					TokenEncloser enc = previous as TokenEncloser;
					if (enc.Side == EncloserSide.Closing)
					{
						minus = true;
					}
				}
				else if (previous.Type == TokenType.Name)
				{
					return true;
				}
			}

			return !minus;
		}

		public override string ToString()
		{
			return "[OperatorNeg]";
		}
	}
}
