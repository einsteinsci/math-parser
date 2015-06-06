using MathParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	public class NodeOperatorLessThanOrEqual : NodeOperatorBinary
	{
		public override string StringForm
		{ get { return "<="; } }

		public override TokenType Operator
		{ get { return TokenType.OperatorLessThanOrEqual; } }

		public override MathType Type
		{ get { return MathType.Boolean; } }

		public NodeOperatorLessThanOrEqual(NodeFactor first, NodeFactor second) :
			base(first, second)
		{ }

		public override IResultValue GetResult()
		{
			return new ResultBoolean(First.GetResult().ToDouble() <= Second.GetResult().ToDouble());
		}
	}
}
