﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;

namespace MathParser.Tokens
{
	[MakeToken("operatorMinus")]
	public class TokenClassOperatorMinus : TokenClassOperator
	{
		public override string Operator
		{ get { return "-"; } }

		public override int Precedence
		{ get { return PREC_ADDITIVE; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorMinus(args[0], args[1]);
		}
	}
}