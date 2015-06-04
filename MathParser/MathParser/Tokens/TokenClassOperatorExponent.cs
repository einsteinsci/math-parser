using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[BinaryOperator("operatorExponent", typeof(NodeOperatorExponent), Precedence.EXPONENTIAL)]
	[MakeTokenClass("operatorExponent")]
	public class TokenClassOperatorExponent : TokenClassOperator
	{
		public override string Operator
		{ get { return "^"; } }

		public override Precedence PrecedenceLevel
		{ get { return Precedence.EXPONENTIAL; } }

		public override bool IsRightAssociative
		{ get { return true; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorExponent(args[0], args[1]);
		}
	}
}
