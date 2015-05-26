using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[MakeToken("operatorLessThanOrEqual")]
	public class TokenOperatorLessThanOrEqual : TokenOperator
	{
		public override string Operator
		{ get { return "<="; } }

		public override int Precedence
		{ get { return PREC_RELATIONAL; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorLessThanOrEqual(args[0], args[1]);
		}
	}
}
