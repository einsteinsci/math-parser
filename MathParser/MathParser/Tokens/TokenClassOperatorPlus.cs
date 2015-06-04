﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[BinaryOperator("operatorPlus", typeof(NodeOperatorPlus), Precedence.ADDITIVE)]
	[MakeTokenClass("operatorPlus")]
	public class TokenClassOperatorPlus : TokenClassOperator
	{
		public override string Operator
		{ get { return "+"; } }
	}
}
