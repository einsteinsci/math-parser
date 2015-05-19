﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.Tokens;
using MathPlusLib;

namespace MathParser.ParseTree
{
	public class NodeOperatorExponent : NodeOperatorBinary
	{
		public override Token Operator
		{ get { return Token.OperatorExponent; } }

		public override MathType Type
		{ get { return MathType.Number; } }

		public override string StringForm
		{ get { return "^"; } }

		public override ResultValue GetResult()
		{
			return new ResultNumber(MathPlus.Pow(First.GetResult().ToDouble(), Second.GetResult().ToDouble()));
		}

		public NodeOperatorExponent(NodeFactor first, NodeFactor second)
		{
			First = first;
			Second = second;
		}
	}
}
