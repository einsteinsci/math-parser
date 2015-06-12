using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Types;

using MathParser.Lexing;

namespace MathParser.ParseTree
{
	public class NodeOperatorDivide : NodeOperatorBinary
	{
		public override TokenTypeOperator Operator
		{ get { return TokenTypes.OperatorDivide as TokenTypeOperator; } }

		public override MathType Type
		{ get { return MathType.Real; } }

		public NodeOperatorDivide(NodeBase first, NodeBase second) :
			base(first, second)
		{ }

		public override IResultValue Evaluate()
		{
			return new ResultNumberReal(First.Evaluate().ToDecimal() / Second.Evaluate().ToDecimal());
		}
	}
}
