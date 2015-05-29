using MathParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	public class NodeOperatorGreaterThanOrEqual : NodeOperatorBinary
	{
		public override string StringForm
		{ get { return ">="; } }

		public override TokenClass Operator
		{ get { return TokenClass.OperatorGreaterThanOrEqual; } }

		public override MathType Type
		{ get { return MathType.Boolean; } }

		public NodeOperatorGreaterThanOrEqual(NodeFactor first, NodeFactor second)
		{
			First = first;
			Second = second;
		}

		public override IResultValue GetResult()
		{
			return new ResultBoolean(First.GetResult().ToDouble() >= Second.GetResult().ToDouble());
		}
	}
}
