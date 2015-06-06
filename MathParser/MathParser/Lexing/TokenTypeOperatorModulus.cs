using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Parsing;

namespace MathParser.Lexing
{
	[BinaryOperator("operatorModulus", typeof(NodeOperatorModulus), Precedence.MULTIPLICATIVE)]
	[TokenType("operatorModulus")]
	public class TokenTypeOperatorModulus : TokenTypeOperator
	{
		public override string Operator
		{ get { return "%"; } }
	}
}
