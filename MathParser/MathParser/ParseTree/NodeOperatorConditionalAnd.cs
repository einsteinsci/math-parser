using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Tokens;

namespace MathParser.ParseTree
{
	public class NodeOperatorConditionalAnd : NodeOperatorBinary
	{
		public override TokenClass Operator
		{ get { return TokenClass.OperatorConditionalAnd; } }

		public override string StringForm
		{ get { return "&&"; } }

		public override MathType Type
		{ get { return MathType.Boolean; } }

		public NodeOperatorConditionalAnd(NodeFactor first, NodeFactor second)
		{
			First = first;
			Second = second;
		}

		public override IResultValue GetResult()
		{
			return new ResultBoolean(First.GetResult().ToBoolean() && Second.GetResult().ToBoolean());
		}
	}
}
