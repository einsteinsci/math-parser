using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[PostfixOperator("operatorFactorial", typeof(NodeOperatorFactorial))]
	[MakeTokenClass("operatorFactorial")]
	public class TokenClassOperatorFactorial : TokenClassOperator
	{
		public override string Operator
		{ get { return "!"; } }
	}
}
