using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[BinaryOperator("operatorGreaterThanOrEqual", typeof(NodeOperatorGreaterThanOrEqual), Precedence.RELATIONAL)]
	[MakeTokenClass("operatorGreaterThanOrEqual")]
	public class TokenClassOperatorGreaterThanOrEqual : TokenClassOperator
	{
		public override string Operator
		{ get { return ">="; } }
	}
}
