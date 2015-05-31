using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[MakeTokenClass("operatorNot")]
	public class TokenClassOperatorNot : TokenClassOperator
	{
		public override string Operator
		{ get { return "~"; } }

		public override int PrecedenceLevel
		{ get { return Precedence.PREFIX; } }

		public override int ArgumentCount
		{ get { return 1; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorNot(args[0]);
		}
	}
}
