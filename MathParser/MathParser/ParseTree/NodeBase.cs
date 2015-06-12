using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Types;

namespace MathParser.ParseTree
{
	/// <summary>
	/// The base class of all nodes that are part of the parse tree.
	/// Not necessarily multiplication.
	/// </summary>
	public abstract class NodeBase : IEvaluatable, ITextDisplayable
	{
		/// <summary>
		/// The type the node evaluates to
		/// </summary>
		public abstract MathType Type
		{ get; }

		/// <summary>
		/// A list of all nodes contained by the node
		/// </summary>
		public abstract List<NodeBase> Children
		{ get; }

		/// <summary>
		/// Gets the name of the node in the syntax tree
		/// </summary>
		public virtual string NodeName
		{ get { return GetType().Name; } }

		/// <summary>
		/// Evaluates the node
		/// </summary>
		public abstract IResultValue Evaluate();

		/// <summary>
		/// Converts the node to a display-friendly format
		/// </summary>
		public virtual string ToDisplayString()
		{
			return Evaluate().ToString();
		}

		/// <summary>
		/// Creates a tree showing the extent of the expression, for 
		/// debugging purposes. Works via recursion.
		/// </summary>
		/// <param name="depthSpaces">
		///   Depth in the tree, in spaces. Each level of depth 
		///   is two spaces.
		/// </param>
		/// <returns>Resulting string containing the entire parse tree</returns>
		public virtual string GetTreeString(string depthSpaces = "")
		{
			string res = depthSpaces + "<" + NodeName + ">\n";
			foreach (NodeBase child in Children)
			{
				res += child.GetTreeString(depthSpaces + "  ");
			}

			return res;
		}
	}
}
