using MathParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	public class NodeOperatorGreaterThan : NodeOperatorBinary
	{
		public override string StringForm
		{ get { return ">"; } }

		public override Token Operator
		{ get { return Token.OperatorGreaterThan; } }

		public override MathType Type
		{ get { return MathType.Boolean; } }

		public NodeOperatorGreaterThan(NodeFactor first, NodeFactor second)
		{
			First = first;
			Second = second;
		}

		public override IResultValue GetResult()
		{
			return new ResultBoolean(First.GetResult().ToDouble() > Second.GetResult().ToDouble());
		}
	}
}
