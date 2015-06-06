using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[TokenType("operatorQuestion")]
	public class TokenTypeOperatorQuestion : TokenTypeOperator
	{
		public override string Operator
		{ get { return "?"; } }
	}
}
