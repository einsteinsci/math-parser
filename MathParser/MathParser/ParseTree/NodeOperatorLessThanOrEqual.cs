using MathParser.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Types;

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

		public NodeOperatorLessThanOrEqual(NodeBase first, NodeBase second) :
			base(first, second)
		{ }

		public override IResultValue Evaluate()
		{
			return new ResultBoolean(First.Evaluate().ToDouble() <= Second.Evaluate().ToDouble());
		}
	}
}
