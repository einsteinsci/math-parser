using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.Tokens;

namespace MathParser.ParseTree
{
	public class NodeOperatorModulus : NodeOperatorBinary
	{
		public override Token Operator
		{
			get { return Token.OperatorModulus; }
		}

		public override MathType Type
		{ get { return MathType.Integer; } }

		public override string StringForm
		{ get { return "%"; } }

		public override IResultValue GetResult()
		{
			return new ResultNumberReal(First.GetResult().ToInteger() % Second.GetResult().ToInteger());
		}

		public NodeOperatorModulus(NodeFactor first, NodeFactor second)
		{
			First = first;
			Second = second;
		}
	}
}
