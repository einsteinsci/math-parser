using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	public class NodeListOrdinal : NodeFactor
	{
		public override MathType Type
		{ get { return MathType.Real; } }

		public override List<NodeFactor> Children
		{
			get
			{
				return new List<NodeFactor>() { List, Index };
			}
		}

		public NodeFactor List
		{ get; private set; }

		public NodeFactor Index
		{ get; private set; }

		public NodeListOrdinal(NodeFactor list, NodeFactor index)
		{
			List = list;
			Index = index;
		}

		public override IResultValue GetResult()
		{
			IResultValue list = List.GetResult();
			IResultValue index = Index.GetResult();

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
