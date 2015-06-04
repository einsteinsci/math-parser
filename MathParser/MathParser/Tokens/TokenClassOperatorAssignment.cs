﻿using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[MakeTokenClass("operatorAssignment")]
	public class TokenClassOperatorAssignment : TokenClassOperator
	{
		public override string Operator
		{ get { return ":="; } }

		public override Precedence PrecedenceLevel
		{ get { return Precedence.ASSIGNMENT; } }

		public override bool IsRightAssociative
		{ get { return true; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorAssigment(args[0], args[1]);
		}
	}
}
