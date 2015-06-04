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
	[MakeTokenClass("operatorModulus")]
	public class TokenClassOperatorModulus : TokenClassOperator
	{
		public override string Operator
		{ get { return "%"; } }
	}
}
