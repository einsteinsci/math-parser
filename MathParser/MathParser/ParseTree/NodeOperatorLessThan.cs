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
		public override TokenTypeOperator Operator
		{ get { return TokenTypes.OperatorLessThan as TokenTypeOperator; } }

		public override MathType Type
		{ get { return MathType.Boolean; } }

		public NodeOperatorLessThan(NodeBase first, NodeBase second) :
			base(first, second)
		{ }

		public override IResultValue Evaluate()
		{
			return new ResultBoolean(First.Evaluate().ToDecimal() < Second.Evaluate().ToDecimal());
		}
	}
}
