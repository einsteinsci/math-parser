using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;

namespace MathParser.Tokens
{
	[MakeToken("operatorBitShiftRight")]
	public class TokenOperatorBitShiftRight : TokenOperator
	{
		public override string Operator
		{ get { return ">>"; } }

		public override int Precedence
		{ get { return PREC_BITSHIFT; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorBitShiftRight(args[0], args[1]);
		}
	}
}
