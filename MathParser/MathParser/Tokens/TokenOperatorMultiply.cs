using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[Token("OperatorMultiply", PRIORITY)]
	public class TokenOperatorMultiply : TokenOperator
	{
		public override string Operator
		{
			get { return "*"; }
		}

		public override int Precedence
		{ get { return 3; } }

		public override bool SingleChar
		{
			get { return true; }
		}
	}
}
