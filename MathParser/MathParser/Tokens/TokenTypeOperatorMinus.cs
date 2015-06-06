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
	[TokenType("operatorMinus")]
	public class TokenTypeOperatorMinus : TokenTypeOperator
	{
		public override string Operator
		{ get { return "-"; } }
	}
}
