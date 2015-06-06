using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[BinaryOperator("operatorMultiply", typeof(NodeOperatorMultiply), Precedence.MULTIPLICATIVE)]
	[TokenType("operatorMultiply")]
	public class TokenTypeOperatorMultiply : TokenTypeOperator
	{
		public override string Operator
		{ get { return "*"; } }
	}
}
