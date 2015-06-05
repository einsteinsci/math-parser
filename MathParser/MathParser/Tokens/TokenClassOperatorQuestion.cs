using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[MakeTokenClass("operatorQuestion")]
	public class TokenClassOperatorQuestion : TokenClassOperator
	{
		public override string Operator
		{ get { return "?"; } }
	}
}
