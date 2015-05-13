using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[Token("operatorBitShiftLeft", PRIORITY)]
	public class TokenOperatorBitShiftLeft : TokenOperator
	{
		public override string Operator
		{
			get { return "<<"; }
		}

		public override int Precedence
		{ get { return 4; } }

		public override bool SingleChar
		{
			get { return false; }
		}
	}
}
