using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[BinaryOperator("operatorLessThanOrEqual", typeof(NodeOperatorLessThanOrEqual), Precedence.RELATIONAL)]
	[MakeTokenClass("operatorLessThanOrEqual")]
	public class TokenClassOperatorLessThanOrEqual : TokenClassOperator
	{
		public override string Operator
		{ get { return "<="; } }
	}
}
