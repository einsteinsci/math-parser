﻿using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[BinaryOperator("operatorLessThan", typeof(NodeOperatorLessThan), Precedence.RELATIONAL)]
	[MakeTokenClass("operatorLessThan")]
	public class TokenClassOperatorLessThan : TokenClassOperator
	{
		public override string Operator
		{ get { return "<"; } }

		public override Precedence PrecedenceLevel
		{ get { return Precedence.RELATIONAL; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorLessThan(args[0], args[1]);
		}
	}
}
