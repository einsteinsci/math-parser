using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[Token("operatorModulus", PRIORITY)]
	public class TokenOperatorModulus : TokenOperator
	{
		public override string Operator
		{
			get { return "%"; }
		}

		public override bool SingleChar
		{
			get { return true; }
		}
	}
}
