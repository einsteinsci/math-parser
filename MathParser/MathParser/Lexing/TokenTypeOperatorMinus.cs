using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Parsing;

namespace MathParser.Lexing
{
	[PrefixOperator("operatorMinus", typeof(NodeOperatorNegative))]
	[BinaryOperator("operatorMinus", typeof(NodeOperatorMinus), Precedence.ADDITIVE)]
	[TokenType("operatorMinus")]
	public class TokenTypeOperatorMinus : TokenTypeOperator
	{
		public override string StringForm
		{ get { return "-"; } }
	}
}
