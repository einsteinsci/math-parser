using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Types;

namespace MathParser.ParseTree
{
	public class NodeIdentifier : NodeBase
	{
		public override MathType Type
		{ get { return StoredValue != null ? StoredValue.Type : (MathType)0; } }

		public IResultValue StoredValue
		{ get; set; }

		public string IdentifierName
		{ get; set; }

		public override string NodeName
		{ get { return IdentifierName; } }

		public override List<NodeBase> Children
		{
			get { return new List<NodeBase>(); }
		}

		public NodeIdentifier(string varName)
		{
			StoredValue = VariableRegistry.Get(varName);
			IdentifierName = varName;
		}

		public override IResultValue Evaluate()
		{
			return StoredValue;
		}

		public override string ToString()
		{
			return IdentifierName;
		}
	}
}
