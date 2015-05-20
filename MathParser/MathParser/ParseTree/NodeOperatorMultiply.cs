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
		public override Token Operator
		{
			get { return Token.OperatorMultiply; }
		}

		public override MathType Type
		{ get { return MathType.Real; } }

		public override string StringForm
		{ get { return "*"; } }

		public override IResultValue GetResult()
		{
			return new ResultNumberReal(First.GetResult().ToDouble() * Second.GetResult().ToDouble());
		}

		public NodeOperatorMultiply(NodeFactor first, NodeFactor second)
		{
			First = first;
			Second = second;
		}
	}
}
