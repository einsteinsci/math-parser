using MathParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	public class NodeOperatorLessThan : NodeOperatorBinary
	{
		public override string StringForm
		{ get { return "<"; } }

		public override Token Operator
		{ get { return Token.OperatorLessThan; } }

		public override MathType Type
		{ get { return MathType.Boolean; } }

		public NodeOperatorLessThan(NodeFactor first, NodeFactor second)
		{
			First = first;
			Second = second;
		}

		public override IResultValue GetResult()
		{
			return new ResultBoolean(First.GetResult().ToDouble() < Second.GetResult().ToDouble());
		}
	}
}
