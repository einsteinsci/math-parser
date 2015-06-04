using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[BinaryOperator("operatorConditionalOr", typeof(NodeOperatorConditionalOr), Precedence.CONDITIONAL_OR)]
	[MakeTokenClass("operatorConditionalOr")]
	public class TokenClassOperatorConditionalOr : TokenClassOperator
	{
		public override string Operator
		{ get { return "||"; } }

		public override Precedence PrecedenceLevel
		{ get { return Precedence.CONDITIONAL_OR; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorConditionalOr(args[0], args[1]);
		}
	}
}
