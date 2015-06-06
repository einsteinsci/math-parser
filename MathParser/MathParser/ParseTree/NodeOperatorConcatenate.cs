using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Tokens;

namespace MathParser.ParseTree
{
	public class NodeOperatorConcatenate : NodeOperatorBinary
	{
		public override TokenType Operator
		{ get { return TokenType.OperatorPlus; } }

		// VB style
		public override string StringForm
		{ get { return "&"; } }

		public override MathType Type
		{ get { return MathType.String; } }

		public NodeOperatorConcatenate(NodeFactor first, NodeFactor second) :
			base(first, second)
		{ }

		public override IResultValue GetResult()
		{
			IResultValue first = First.GetResult();
			IResultValue second = Second.GetResult();

			return new ResultString(First.GetResult().ToString() + Second.GetResult().ToString());
		}
	}
}
