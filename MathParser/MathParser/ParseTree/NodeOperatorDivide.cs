﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.Tokens;

namespace MathParser.ParseTree
{
	public class NodeOperatorDivide : NodeOperatorBinary
	{
		public override Token Operator
		{
			get { return Token.OperatorDivide; }
		}

		public override string StringForm
		{ get { return "/"; } }

		public override double GetResult()
		{
			return First.GetResult().ToDouble() / Second.GetResult().ToDouble();
		}

		public NodeOperatorDivide(NodeFactor first, NodeFactor second)
		{
			First = first;
			Second = second;
		}
	}
}