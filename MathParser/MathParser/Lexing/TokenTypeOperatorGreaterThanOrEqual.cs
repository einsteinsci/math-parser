using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Parsing;

namespace MathParser.Lexing
{
	[BinaryOperator("operatorGreaterThanOrEqual", typeof(NodeOperatorGreaterThanOrEqual), Precedence.RELATIONAL)]
	[TokenType("operatorGreaterThanOrEqual")]
	public class TokenTypeOperatorGreaterThanOrEqual : TokenTypeOperator
	{
		public override string Operator
		{ get { return ">="; } }
	}
}
