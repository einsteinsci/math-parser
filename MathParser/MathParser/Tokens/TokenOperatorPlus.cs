using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[Token("operatorPlus", PRIORITY)]
	public class TokenOperatorPlus : TokenOperator
	{
		public override string Operator
		{ get { return "+"; } }

		public override int Precedence
		{ get { return PREC_ADDITIVE; } }

		public override bool SingleChar
		{ get { return true; } }
	}
}
