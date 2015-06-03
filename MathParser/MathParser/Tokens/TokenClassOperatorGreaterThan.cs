using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[BinaryOperator("operatorGreaterThan", typeof(NodeOperatorGreaterThan), Precedence.RELATIONAL)]
	[MakeTokenClass("operatorGreaterThan")]
	public class TokenClassOperatorGreaterThan : TokenClassOperator
	{
		public override string Operator
		{ get { return ">"; } }

		public override int PrecedenceLevel
		{ get { return Precedence.RELATIONAL; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorGreaterThan(args[0], args[1]);
		}
	}
}
