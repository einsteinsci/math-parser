using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[Token("OperatorDivide", PRIORITY)]
	public class TokenOperatorDivide : TokenOperator
	{
		public override string Operator
		{
			get { return "/"; }
		}

		public override int Precedence
		{ get { return 2; } }

		public override bool SingleChar
		{
			get { return true; }
		}
	}
}
