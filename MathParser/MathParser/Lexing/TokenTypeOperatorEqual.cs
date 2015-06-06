using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Parsing;

namespace MathParser.Lexing
{
	[BinaryOperator("operatorEqual", typeof(NodeOperatorEqual), Precedence.EQUALITY)]
	[TokenType("operatorEqual")]
	public class TokenTypeOperatorEqual : TokenTypeOperator
	{
		public override string Operator
		{ get { return "=="; } }
	}
}
