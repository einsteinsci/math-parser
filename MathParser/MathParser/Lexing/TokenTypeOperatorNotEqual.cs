using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Parsing;

namespace MathParser.Lexing
{
	[BinaryOperator("operatorNotEqual", typeof(NodeOperatorNotEqual), Precedence.EQUALITY)]
	[TokenType("operatorNotEqual")]
	public class TokenTypeOperatorNotEqual : TokenTypeOperator
	{
		public override string Operator
		{ get { return "~="; } }
	}
}
