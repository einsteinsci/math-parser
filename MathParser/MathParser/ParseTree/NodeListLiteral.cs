using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Types;

namespace MathParser.ParseTree
{
	public class NodeListLiteral : NodeBase
	{
		public override List<NodeBase> Children
		{ get { return elements; } }
		private List<NodeBase> elements;

		public override MathType Type
		{ get { return MathType.List; } }

		public override string NodeName
		{ get { return "list"; } }

		public NodeListLiteral(IEnumerable<NodeBase> nodes)
		{
			elements = nodes.ToList();
		}
		public NodeListLiteral(params NodeBase[] nodes) : this(nodes.ToList())
		{ }
		public NodeListLiteral()
		{
			elements = new List<NodeBase>();
		}

		public override IResultValue Evaluate()
		{
			List<decimal> vals = new List<decimal>();
			foreach (NodeBase node in Children)
			{
				IResultValue res = node.Evaluate();
				if (res.Type != MathType.Real && res.Type != MathType.Integer)
				{
					throw new EvaluationException(this, "List item must be a number. Found " + 
						res.Type + " instead.");
				}
				vals.Add(res.ToDecimal());
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
