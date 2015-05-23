﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;

namespace MathParser.Tokens
{
	[MakeToken("operatorConditionalOr")]
	public class TokenOperatorConditionalOr : TokenOperator
	{
		public override string Operator
		{ get { return "||"; } }

		public override int Precedence
		{ get { return PREC_CONDITIONAL_OR; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorConditionalOr(args[0], args[1]);
		}
	}
}
