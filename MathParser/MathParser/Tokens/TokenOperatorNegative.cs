using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;

namespace MathParser.Tokens
{
	[MakeToken("operatorNegative", PRIORITY)]
	public class TokenOperatorNegative : TokenOperator
	{
		public override string Operator
		{ get { return "-"; } }

		public override int Precedence
		{ get { return PREC_UNARY; } }

		public override bool SingleChar
		{ get { return true; } }

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
