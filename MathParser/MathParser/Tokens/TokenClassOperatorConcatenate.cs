using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[BinaryOperator("operatorConcatenate", typeof(NodeOperatorConcatenate), Precedence.ADDITIVE)]
	[MakeTokenClass("operatorConcatenate")]
	public class TokenClassOperatorConcatenate : TokenClassOperator
	{
		public override string Operator
		{ get { return "&"; } }
	}
}
