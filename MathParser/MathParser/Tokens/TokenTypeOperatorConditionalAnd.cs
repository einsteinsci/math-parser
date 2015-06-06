using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[BinaryOperator("operatorConditionalAnd", typeof(NodeOperatorConditionalAnd), Precedence.CONDITIONAL_AND)]
	[TokenType("operatorConditionalAnd")]
	public class TokenTypeOperatorConditionalAnd : TokenTypeOperator
	{
		public override string Operator
		{ get { return "&&"; } }
	}
}
