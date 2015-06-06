using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Types;

namespace MathParser.ParseTree
{
	/// <summary>
	/// Not necessarily multiplication.
	/// </summary>
	public abstract class NodeFactor : IEvaluatable, ITextDisplayable
	{
		public abstract MathType Type
		{ get; }

		public abstract List<NodeFactor> Children
		{ get; }

		public virtual string NodeName
		{ get { return GetType().Name; } }

		public NodeFactor Parent
		{ get; protected set; }

		public abstract IResultValue GetResult();

		public virtual string GetResultString()
		{
			return GetResult().ToString();
		}

		public virtual string GetTreeString(string depthSpaces = "")
		{
			string res = depthSpaces + "<" + NodeName + ">\n";
			foreach (NodeFactor child in Children)
			{
				res += child.GetTreeString(depthSpaces + "  ");
			}

			return res;
		}
	}
}
