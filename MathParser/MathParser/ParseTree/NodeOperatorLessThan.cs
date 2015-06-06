using MathParser.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Types;

namespace MathParser.ParseTree
{
	public class NodeOperatorLessThan : NodeOperatorBinary
	{
		public override string StringForm
		{ get { return "<"; } }

		public override TokenType Operator
		{ get { return TokenType.OperatorLessThan; } }

		public override MathType Type
		{ get { return MathType.Boolean; } }

		public NodeOperatorLessThan(NodeFactor first, NodeFactor second) :
			base(first, second)
		{ }

		public override IResultValue GetResult()
		{
			return new ResultBoolean(First.GetResult().ToDouble() < Second.GetResult().ToDouble());
		}
	}
}
