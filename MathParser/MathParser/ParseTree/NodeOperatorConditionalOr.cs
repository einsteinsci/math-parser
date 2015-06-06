using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Lexing;
using MathParser.Types;

namespace MathParser.ParseTree
{
	public class NodeOperatorConditionalOr : NodeOperatorBinary
	{
		public override TokenType Operator
		{ get { return TokenType.OperatorConditionalOr; } }

		public override string StringForm
		{ get { return "||"; } }

		public override MathType Type
		{ get { return MathType.Boolean; } }

		public NodeOperatorConditionalOr(NodeFactor first, NodeFactor second) :
			base(first, second)
		{ }

		public override IResultValue GetResult()
		{
			return new ResultBoolean(First.GetResult().ToBoolean() || Second.GetResult().ToBoolean());
		}
	}
}
