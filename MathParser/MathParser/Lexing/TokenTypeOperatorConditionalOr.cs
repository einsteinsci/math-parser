using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Parsing;

namespace MathParser.Lexing
{
	[BinaryOperator("operatorConditionalOr", typeof(NodeOperatorConditionalOr), Precedence.CONDITIONAL_OR)]
	[TokenType("operatorConditionalOr")]
	public class TokenTypeOperatorConditionalOr : TokenTypeOperator
	{
		public override string Operator
		{ get { return "||"; } }
	}
}
