using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[BinaryOperator("operatorPlus", typeof(NodeOperatorPlus), Precedence.ADDITIVE)]
	[MakeTokenClass("operatorPlus")]
	public class TokenClassOperatorPlus : TokenClassOperator
	{
		public override string Operator
		{ get { return "+"; } }

		public override Precedence PrecedenceLevel
		{ get { return Precedence.ADDITIVE; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			if (args[0].Type == MathType.String || args[1].Type == MathType.String)
			{
				return new NodeOperatorConcatenate(args[0], args[1]);
			}

			return new NodeOperatorPlus(args[0], args[1]);
		}
	}
}
