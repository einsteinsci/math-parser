using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[PrefixOperator("operatorMinus", typeof(NodeOperatorNegative))]
	[BinaryOperator("operatorMinus", typeof(NodeOperatorMinus), Precedence.ADDITIVE)]
	[MakeTokenClass("operatorMinus")]
	public class TokenClassOperatorMinus : TokenClassOperator
	{
		public override string Operator
		{ get { return "-"; } }

		public override int PrecedenceLevel
		{ get { return Precedence.ADDITIVE; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorMinus(args[0], args[1]);
		}
	}
}
