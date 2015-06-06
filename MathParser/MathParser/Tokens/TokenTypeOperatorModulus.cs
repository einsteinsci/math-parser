using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[BinaryOperator("operatorModulus", typeof(NodeOperatorModulus), Precedence.MULTIPLICATIVE)]
	[TokenType("operatorModulus")]
	public class TokenTypeOperatorModulus : TokenTypeOperator
	{
		public override string Operator
		{ get { return "%"; } }
	}
}
