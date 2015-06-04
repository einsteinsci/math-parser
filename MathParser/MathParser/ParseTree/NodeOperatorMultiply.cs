using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.Tokens;

namespace MathParser.ParseTree
{
	public class NodeOperatorMultiply : NodeOperatorBinary
	{
		public override TokenClass Operator
		{
			get { return TokenClass.OperatorMultiply; }
		}

		public override MathType Type
		{ get { return MathType.Real; } }

		public override string StringForm
		{ get { return "*"; } }

		public NodeOperatorMultiply(NodeFactor first, NodeFactor second) :
			base(first, second)
		{ }

		public override IResultValue GetResult()
		{
			return new ResultNumberReal(First.GetResult().ToDouble() * Second.GetResult().ToDouble());
		}
	}
}
