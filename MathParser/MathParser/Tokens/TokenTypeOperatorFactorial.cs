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
	[TokenType("operatorFactorial")]
	public class TokenTypeOperatorFactorial : TokenTypeOperator
	{
		public override string Operator
		{ get { return "!"; } }
	}
}
