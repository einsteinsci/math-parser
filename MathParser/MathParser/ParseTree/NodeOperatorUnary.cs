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
		/// <summary>
		/// Node the operator is applied to
		/// </summary>
		public NodeBase Operand
		{ get; protected set; }

		/// <summary>
		/// The string form of the operator, for debugging
		/// purposes
		/// </summary>
		public virtual string StringForm
		{ get { return Operator.StringForm; } }

		/// <summary>
		/// Name of node in debug displays
		/// </summary>
		public override string NodeName
		{ get { return "Operator " + StringForm + " "; } }

		/// <summary>
		/// List of all children of the node
		/// </summary>
		public override List<NodeBase> Children
		{
			get
			{
				return new List<NodeBase>() { Operand };
			}
		}

		/// <summary>
		/// Token type used when identifying the operator
		/// </summary>
		public abstract TokenTypeOperator Operator
		{ get; }

		/// <summary>
		/// Constructor to inherit
		/// </summary>
		public NodeOperatorUnary(NodeBase operand)
		{
			Operand = operand;
		}

		/// <summary>
		/// Converts the operator to a string
		/// </summary>
		public override string ToString()
		{
			return "(" + StringForm + Operand.ToString() + ")";
		}
	}
}
