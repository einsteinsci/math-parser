using MathParser.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Types;

namespace MathParser.ParseTree
{
	public abstract class NodeOperatorBinary : NodeBase
	{
		public NodeBase First
		{ get; protected set; }

		public NodeBase Second
		{ get; protected set; }

		public abstract string StringForm
		{ get; }

		public override string NodeName
		{ get { return "Operator " + StringForm + " "; } }

		public override List<NodeBase> Children
		{
			get
			{
				List<NodeBase> res = new List<NodeBase>();
				res.Add(First);
				res.Add(Second);
				return res;
			}
		}

		public abstract TokenType Operator
		{ get; }

		public virtual bool IsRightAssociative
		{ get { return false; } }

		public NodeOperatorBinary(NodeBase first, NodeBase second)
		{
			First = first;
			Second = second;
		}

		public override string ToString()
		{
			return "(" + First.ToString() + " " + StringForm + " " + Second.ToString() + ")";
		}
	}
}
