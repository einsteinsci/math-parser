﻿using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[BinaryOperator("operatorBitShiftLeft", typeof(NodeOperatorBitShiftLeft), Precedence.BITSHIFT)]
	[MakeTokenClass("operatorBitShiftLeft")]
	public class TokenClassOperatorBitShiftLeft : TokenClassOperator
	{
		public override string Operator
		{ get { return "<<"; } }
	}
}
