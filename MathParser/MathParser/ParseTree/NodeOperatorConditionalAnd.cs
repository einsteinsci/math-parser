using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Lexing;
using MathParser.Types;

namespace MathParser.ParseTree
{
	public class NodeOperatorConditionalAnd : NodeOperatorBinary
	{
		public override TokenType Operator
		{ get { return TokenType.OperatorConditionalAnd; } }

		public override string StringForm
		{ get { return "&&"; } }

		public override MathType Type
		{ get { return MathType.Boolean; } }

		public NodeOperatorConditionalAnd(NodeBase first, NodeBase second) :
			base(first, second)
		{ }

		public override IResultValue Evaluate()
		{
			return new ResultBoolean(First.Evaluate().ToBoolean() && Second.Evaluate().ToBoolean());
		}
	}
}
