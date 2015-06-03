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
		{ get { return StoredValue.Type; } }

		public IResultValue StoredValue
		{ get; set; }

		public string IdentifierName
		{ get; set; }

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
