using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[MakeTokenClass("operatorFactorial")]
	public class TokenClassOperatorFactorial : TokenClassOperator
	{
		public override string Operator
		{ get { return "!"; } }

		public override int PrecedenceLevel
		{ get { return Precedence.PRIMARY; } } // highest precedence

		public override int ArgumentCount
		{ get { return 1; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorFactorial(args[0]);
		}
	}
}
