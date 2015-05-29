﻿using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[MakeToken("operatorBitShiftLeft")]
	public class TokenClassOperatorBitShiftLeft : TokenClassOperator
	{
		public override string Operator
		{ get { return "<<"; } }

		public override int Precedence
		{ get { return PREC_BITSHIFT; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorBitShiftLeft(args[0], args[1]);
		}
	}
}