﻿using MathParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	public abstract class NodeOperatorUnary : NodeFactor
	{
		public NodeFactor Operand
		{ get; protected set; }

		public abstract string StringForm
		{ get; }

		public override string NodeName
		{ get { return "Operator " + StringForm + " "; } }

		public override List<NodeFactor> Children
		{
			get
			{
				return new List<NodeFactor>() { Operand };
			}
		}

		public abstract TokenClass Operator
		{ get; }

		public NodeOperatorUnary(NodeFactor operand)
		{
			Operand = operand;
		}

		public override string ToString()
		{
			return "(" + StringForm + Operand.ToString() + ")";
		}
	}
}
