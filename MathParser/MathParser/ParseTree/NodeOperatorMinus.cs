using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	public class NodeOperatorMinus : NodeOperatorBinary
	{
		public override Tokens.TokenClass Operator
		{
			get { return Tokens.TokenClass.OperatorMinus; }
		}

		public override MathType Type
		{ get { return MathType.Real; } }

		public override string StringForm
		{ get { return "-"; } }

		public override IResultValue GetResult()
		{
			return new ResultNumberReal(First.GetResult().ToDouble() - Second.GetResult().ToDouble());
		}

		public NodeOperatorMinus(NodeFactor first, NodeFactor second)
		{
			First = first;
			Second = second;
		}
	}
}
