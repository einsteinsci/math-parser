using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[MakeTokenClass("operatorModulus")]
	public class TokenClassOperatorModulus : TokenClassOperator
	{
		public override string Operator
		{ get { return "%"; } }

		public override int PrecedenceLevel
		{ get { return Precedence.MULTIPLICATIVE; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorModulus(args[0], args[1]);
		}
	}
}
