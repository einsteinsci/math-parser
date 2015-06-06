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
		public override TokenType Operator
		{
			get { return TokenType.OperatorPlus; }
		}

		public override MathType Type
		{ get { return MathType.Real; } }

		public override string StringForm
		{ get { return "+"; } }

		public NodeOperatorPlus(NodeFactor first, NodeFactor second) :
			base(first, second)
		{ }

		public override IResultValue GetResult()
		{
			return new ResultNumberReal(First.GetResult().ToDouble() + Second.GetResult().ToDouble());
		}
	}
}
