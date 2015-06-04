using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	public class NodeIdentifier : NodeFactor
	{
		public override MathType Type
		{ get { return StoredValue != null ? StoredValue.Type : (MathType)0; } }

		public IResultValue StoredValue
		{ get; set; }

		public string IdentifierName
		{ get; set; }

		public override string NodeName
		{ get { return IdentifierName; } }

		public override List<NodeFactor> Children
		{
			get { return new List<NodeFactor>(); }
		}

		public NodeIdentifier(string varName)
		{
			StoredValue = VariableRegistry.Get(varName);
			IdentifierName = varName;
		}

		public override IResultValue GetResult()
		{
			return StoredValue;
		}

		public override string ToString()
		{
			return IdentifierName;
		}
	}
}
