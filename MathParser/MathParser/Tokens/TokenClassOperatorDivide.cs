using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[BinaryOperator("operatorDivide", typeof(NodeOperatorDivide), Precedence.MULTIPLICATIVE)]
	[MakeTokenClass("operatorDivide")]
	public class TokenClassOperatorDivide : TokenClassOperator
	{
		public override string Operator
		{ get { return "/"; } }
	}
}
