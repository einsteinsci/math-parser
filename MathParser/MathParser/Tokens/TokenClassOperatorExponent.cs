﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;

namespace MathParser.Tokens
{
	[MakeToken("operatorExponent")]
	public class TokenClassOperatorExponent : TokenClassOperator
	{
		public override string Operator
		{ get { return "^"; } }

		public override int Precedence
		{ get { return PREC_EXPONENTIAL; } }

		public override bool IsRightAssociative
		{ get { return true; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorExponent(args[0], args[1]);
		}
	}
}