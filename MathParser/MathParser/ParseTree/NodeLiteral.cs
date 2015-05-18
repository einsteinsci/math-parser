using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	public class NodeLiteral : NodeFactor
	{
		public ResultValue Value
		{ get; set; }

		public override List<NodeFactor> Children
		{
			get { return new List<NodeFactor>(); }
		}

		public override ResultValue GetResult()
		{
			return Value;
		}

		public NodeLiteral(ResultValue val)
		{
			Value = val;
		}

		public override string ToString()
		{
			return Value.ToString();
		}
	}
}
