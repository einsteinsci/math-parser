using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Lexing
{
	[TokenType("operatorColon")]
	public class TokenTypeOperatorColon : TokenTypeOperator
	{
		public override string StringForm
		{ get { return ":"; } }
	}
}
