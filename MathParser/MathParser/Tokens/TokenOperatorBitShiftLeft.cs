using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[MakeToken("operatorBitShiftLeft")]
	public class TokenOperatorBitShiftLeft : TokenOperator
	{
		public override string Operator
		{ get { return "<<"; } }

		public override int Precedence
		{ get { return PREC_BITSHIFT; } }

		public override bool SingleChar
		{ get { return false; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorBitShiftLeft(args[0], args[1]);
		}
	}
}
