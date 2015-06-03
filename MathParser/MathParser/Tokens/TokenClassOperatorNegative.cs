using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[Obsolete]
	[PrefixOperator("operatorNegative", typeof(NodeOperatorNegative))]
	[MakeTokenClass("operatorNegative")]
	public class TokenClassOperatorNegative : TokenClassOperator
	{
		public override string Operator
		{ get { return "-"; } }

		public override int PrecedenceLevel
		{ get { return Precedence.PREFIX; } }

		public override int ArgumentCount
		{ get { return 1; } }

		public override bool Matches(string lexeme)
		{
			return false;
		}

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorNegative(args[0]);
		}

		public override string ToString()
		{
			return "[OperatorNeg]";
		}
	}
}
