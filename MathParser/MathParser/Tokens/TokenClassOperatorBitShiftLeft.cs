using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[BinaryOperator("operatorBitShiftLeft", typeof(NodeOperatorBitShiftLeft), Precedence.BITSHIFT)]
	[MakeTokenClass("operatorBitShiftLeft")]
	public class TokenClassOperatorBitShiftLeft : TokenClassOperator
	{
		public override string Operator
		{ get { return "<<"; } }

		public override Precedence PrecedenceLevel
		{ get { return Precedence.BITSHIFT; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorBitShiftLeft(args[0], args[1]);
		}
	}
}
