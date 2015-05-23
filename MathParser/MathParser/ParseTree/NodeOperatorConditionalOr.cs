using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Tokens;

namespace MathParser.ParseTree
{
	public class NodeOperatorConditionalOr : NodeOperatorBinary
	{
		public override Token Operator
		{ get { return Token.OperatorConditionalOr; } }

		public override string StringForm
		{ get { return "||"; } }

		public override MathType Type
		{ get { return MathType.Boolean; } }

		public NodeOperatorConditionalOr(NodeFactor first, NodeFactor second)
		{
			First = first;
			Second = second;
		}

		public override IResultValue GetResult()
		{
			return new ResultBoolean(First.GetResult().ToBoolean() || Second.GetResult().ToBoolean());
		}
	}
}
