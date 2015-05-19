using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	public class NodeOperatorMinus : NodeOperatorBinary
	{
		public override Tokens.Token Operator
		{
			get { return Tokens.Token.OperatorMinus; }
		}

		public override MathType Type
		{ get { return MathType.Number; } }

		public override string StringForm
		{ get { return "-"; } }

		public override ResultValue GetResult()
		{
			return new ResultNumber(First.GetResult().ToDouble() - Second.GetResult().ToDouble());
		}

		public NodeOperatorMinus(NodeFactor first, NodeFactor second)
		{
			First = first;
			Second = second;
		}
	}
}
