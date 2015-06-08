using MathParser.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Types;

namespace MathParser.ParseTree
{
	public abstract class NodeOperatorUnary : NodeBase
	{
		public NodeBase Operand
		{ get; protected set; }

		public abstract string StringForm
		{ get; }

		public override string NodeName
		{ get { return "Operator " + StringForm + " "; } }

		public override List<NodeBase> Children
		{
			get
			{
				return new List<NodeBase>() { Operand };
			}
		}

		public abstract TokenType Operator
		{ get; }

		public NodeOperatorUnary(NodeBase operand)
		{
			Operand = operand;
		}

		public override string ToString()
		{
			return "(" + StringForm + Operand.ToString() + ")";
		}
	}
}
