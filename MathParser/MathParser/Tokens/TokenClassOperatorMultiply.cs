﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;

namespace MathParser.Tokens
{
	[MakeToken("operatorMultiply")]
	public class TokenClassOperatorMultiply : TokenClassOperator
	{
		public override string Operator
		{ get { return "*"; } }

		public override int Precedence
		{ get { return PREC_MULTIPLICATIVE; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorMultiply(args[0], args[1]);
		}
	}
}