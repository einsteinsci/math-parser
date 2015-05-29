using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[MakeToken("operatorGreaterThan")]
	public class TokenClassOperatorGreaterThan : TokenClassOperator
	{
		public override string Operator
		{ get { return ">"; } }

		public override int Precedence
		{ get { return PREC_RELATIONAL; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorGreaterThan(args[0], args[1]);
		}
	}
}
