using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.Tokens;

namespace MathParser.ParseTree
{
	public class NodeOperatorPlus : NodeOperatorBinary
	{
		public override Token Operator
		{
			get { return Token.OperatorPlus; }
		}

		public override MathType Type
		{ get { return MathType.Number; } }

		public override string StringForm
		{ get { return "+"; } }

		public override ResultValue GetResult()
		{
			return new ResultNumber(First.GetResult().ToDouble() + Second.GetResult().ToDouble());
		}

		public NodeOperatorPlus(NodeFactor first, NodeFactor second)
		{
			First = first;
			Second = second;
		}
	}
}
