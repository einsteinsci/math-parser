using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Types;

namespace MathParser.ParseTree
{
	public class NodeListOrdinal : NodeBase
	{
		public override MathType Type
		{ get { return MathType.Real; } }

		public override List<NodeBase> Children
		{
			get
			{
				return new List<NodeBase>() { List, Index };
			}
		}

		public NodeBase List
		{ get; private set; }

		public NodeBase Index
		{ get; private set; }

		public NodeListOrdinal(NodeBase list, NodeBase index)
		{
			List = list;
			Index = index;
		}

		public override IResultValue Evaluate()
		{
			IResultValue list = List.Evaluate();
			IResultValue index = Index.Evaluate();

			if (index.Type != MathType.Integer)
			{
				throw new EvaluationException(this, "Ordinal index must be integer.");
			}
			if (list.Type != MathType.List)
			{
				throw new EvaluationException(this, "Ordinal access can only be used on a list.");
			}

			return new ResultNumberReal(list.ToList()[(int)index.ToInteger()]);
		}
	}
}
