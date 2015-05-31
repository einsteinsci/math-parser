using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[MakeTokenClass("operatorBitShiftRight")]
	public class TokenClassOperatorBitShiftRight : TokenClassOperator
	{
		public override string Operator
		{ get { return ">>"; } }

		public override int PrecedenceLevel
		{ get { return Precedence.BITSHIFT; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorBitShiftRight(args[0], args[1]);
		}
	}
}
