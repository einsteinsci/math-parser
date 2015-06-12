using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Parsing;

namespace MathParser.Lexing
{
	[BinaryOperator("operatorLessThan", typeof(NodeOperatorLessThan), Precedence.RELATIONAL)]
	[TokenType("operatorLessThan")]
	public class TokenTypeOperatorLessThan : TokenTypeOperator
	{
		public override string StringForm
		{ get { return "<"; } }
	}
}
