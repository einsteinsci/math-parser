using MathParser.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Types;

namespace MathParser.ParseTree
{
	public abstract class NodeOperatorBinary : NodeFactor
	{
		public NodeFactor First
		{ get; protected set; }

		public NodeFactor Second
		{ get; protected set; }

		public abstract string StringForm
		{ get; }

		public override string NodeName
		{ get { return "Operator " + StringForm + " "; } }

		public override List<NodeFactor> Children
		{
			get
			{
				List<NodeFactor> res = new List<NodeFactor>();
				res.Add(First);
				res.Add(Second);
				return res;
			}
		}

		public abstract TokenType Operator
		{ get; }

		public virtual bool IsRightAssociative
		{ get { return false; } }

		public NodeOperatorBinary(NodeFactor first, NodeFactor second)
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
