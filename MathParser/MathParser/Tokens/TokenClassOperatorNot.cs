using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[MakeToken("operatorNot")]
	public class TokenClassOperatorNot : TokenClassOperator
	{
		public override string Operator
		{ get { return "~"; } }

		public override int Precedence
		{ get { return PREC_UNARY; } }

		public override int ArgumentCount
		{ get { return 1; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorNot(args[0]);
		}
	}
}
