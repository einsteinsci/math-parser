using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[BinaryOperator("operatorPlus", typeof(NodeOperatorPlus), Precedence.ADDITIVE)]
	[TokenType("operatorPlus")]
	public class TokenTypeOperatorPlus : TokenTypeOperator
	{
		public override string Operator
		{ get { return "+"; } }
	}
}
