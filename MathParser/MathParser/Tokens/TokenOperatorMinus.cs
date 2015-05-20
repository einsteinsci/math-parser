using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[Token("operatorMinus", PRIORITY)]
	public class TokenOperatorMinus : TokenOperator
	{
		public override string Operator
		{ get { return "-"; } }

		public override int Precedence
		{ get { return PREC_ADDITIVE; } }

		public override bool SingleChar
		{ get { return true; } }
	}
}
