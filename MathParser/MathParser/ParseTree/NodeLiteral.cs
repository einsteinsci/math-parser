using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Types;

namespace MathParser.ParseTree
{
	public class NodeLiteral : NodeBase
	{
		public IResultValue Value
		{ get; set; }

		public override List<NodeBase> Children
		{
			get { return new List<NodeBase>(); }
		}

		public override string NodeName
		{ get { return Type.ToString() + " " + Value.ToDisplayString(); } }

		public override IResultValue Evaluate()
		{
			return Value;
		}

		public override MathType Type
		{ get { return _type; } }
		private MathType _type;

		public NodeLiteral(IResultValue val)
		{
			Value = val;
			_type = val.Type;
		}

		public override string ToString()
		{
			return Value.ToDisplayString();
		}
	}
}
