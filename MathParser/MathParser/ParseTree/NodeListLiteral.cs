using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	public class NodeListLiteral : NodeFactor
	{
		public override List<NodeFactor> Children
		{ get { return elements; } }
		private List<NodeFactor> elements;

		public override MathType Type
		{ get { return MathType.List; } }

		public NodeListLiteral(IEnumerable<NodeFactor> nodes)
		{
			elements = nodes.ToList();
		}
		public NodeListLiteral(params NodeFactor[] nodes) : this(nodes.ToList())
		{ }
		public NodeListLiteral()
		{
			elements = new List<NodeFactor>();
		}

		public override IResultValue GetResult()
		{
			List<double> vals = new List<double>();
			foreach (NodeFactor node in Children)
			{
				IResultValue res = node.GetResult();
				if (res.Type != MathType.Real && res.Type != MathType.Integer)
				{
					throw new Exception("List item must be a number. Found " + 
						res.Type + " instead.");
				}
				vals.Add(res.ToDouble());
			}

			return new ResultList(vals);
		}

		public override string ToString()
		{
			string res = "{ ";
			for (int i = 0; i < Children.Count; i++)
			{
				res += Children[i].ToString();

				if (i < Children.Count - 1)
				{
					res += ", ";
				}
			}

			return res + " }";
		}
	}
}
