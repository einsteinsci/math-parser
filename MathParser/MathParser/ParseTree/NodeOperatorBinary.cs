using MathParser.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Types;

namespace MathParser.ParseTree
{
	/// <summary>
	/// Base class for binary operator nodes
	/// </summary>
	public abstract class NodeOperatorBinary : NodeBase
	{
		/// <summary>
		/// First term, left-hand side
		/// </summary>
		public NodeBase First
		{ get; protected set; }

		/// <summary>
		/// Second term, right-hand side
		/// </summary>
		public NodeBase Second
		{ get; protected set; }

		/// <summary>
		/// The symbol used in the operator, for debugging
		/// purposes.
		/// </summary>
		public virtual string StringForm
		{ get { return Operator.StringForm; } }

		/// <summary>
		/// The name used for the node when debugging
		/// </summary>
		public override string NodeName
		{ get { return "Operator " + StringForm + " "; } }

		/// <summary>
		/// List of all children of the node.
		/// </summary>
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

		/// <summary>
		/// TokenType used to link token type to operator
		/// </summary>
		public abstract TokenTypeOperator Operator
		{ get; }

		/// <summary>
		/// Constructor to inherit from
		/// </summary>
		public NodeOperatorBinary(NodeBase first, NodeBase second)
		{
			First = first;
			Second = second;
		}

		/// <summary>
		/// Converts the node to a string
		/// </summary>
		public override string ToString()
		{
			return "(" + First.ToString() + " " + StringForm + " " + Second.ToString() + ")";
		}
	}
}
