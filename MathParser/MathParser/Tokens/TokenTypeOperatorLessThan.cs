using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[BinaryOperator("operatorLessThan", typeof(NodeOperatorLessThan), Precedence.RELATIONAL)]
	[TokenType("operatorLessThan")]
	public class TokenTypeOperatorLessThan : TokenTypeOperator
	{
		public override string Operator
		{ get { return "<"; } }
	}
}
