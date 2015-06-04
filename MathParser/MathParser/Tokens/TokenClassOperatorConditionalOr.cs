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
	}
}
