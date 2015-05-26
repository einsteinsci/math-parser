using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[MakeToken("operatorAssignment")]
	public class TokenOperatorAssignment : TokenOperator
	{
		public override string Operator
		{ get { return ":="; } }

		public override int Precedence
		{ get { return PREC_ASSIGNMENT; } }

		public override bool IsRightAssociative
		{ get { return true; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorAssigment(args[0], args[1]);
		}
	}
}
