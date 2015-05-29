using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;

namespace MathParser.Tokens
{
	[MakeToken("operatorConditionalAnd")]
	public class TokenClassOperatorConditionalAnd : TokenClassOperator
	{
		public override string Operator
		{ get { return "&&"; } }

		public override int Precedence
		{ get { return PREC_CONDITIONAL_AND; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorConditionalAnd(args[0], args[1]);
		}
	}
}
