using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Parsing;

namespace MathParser.Lexing
{
	[BinaryOperator("operatorLessThanOrEqual", typeof(NodeOperatorLessThanOrEqual), Precedence.RELATIONAL)]
	[TokenType("operatorLessThanOrEqual")]
	public class TokenTypeOperatorLessThanOrEqual : TokenTypeOperator
	{
		public override string StringForm
		{ get { return "<="; } }
	}
}
