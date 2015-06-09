using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Parsing;

namespace MathParser.Lexing
{
	[BinaryOperator("operatorConcatenate", typeof(NodeOperatorConcatenate), Precedence.ADDITIVE)]
	[TokenType("operatorConcatenate")]
	public class TokenTypeOperatorConcatenate : TokenTypeOperator
	{
		public override string Operator
		{ get { return "<>"; } }
	}
}
