using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Parsing;

namespace MathParser.Lexing
{
	[BinaryOperator("operatorDivide", typeof(NodeOperatorDivide), Precedence.MULTIPLICATIVE)]
	[TokenType("operatorDivide")]
	public class TokenTypeOperatorDivide : TokenTypeOperator
	{
		public override string Operator
		{ get { return "/"; } }
	}
}
