using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Parsing;

namespace MathParser.Lexing
{
	[BinaryOperator("operatorPlus", typeof(NodeOperatorPlus), Precedence.ADDITIVE)]
	[TokenType("operatorPlus")]
	public class TokenTypeOperatorPlus : TokenTypeOperator
	{
		public override string Operator
		{ get { return "+"; } }
	}
}
