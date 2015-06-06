using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Parsing;

namespace MathParser.Lexing
{
	[BinaryOperator("operatorExponent", typeof(NodeOperatorExponent), Precedence.EXPONENTIAL)]
	[TokenType("operatorExponent")]
	public class TokenTypeOperatorExponent : TokenTypeOperator
	{
		public override string Operator
		{ get { return "^"; } }

		public override bool IsRightAssociative
		{ get { return true; } }
	}
}
