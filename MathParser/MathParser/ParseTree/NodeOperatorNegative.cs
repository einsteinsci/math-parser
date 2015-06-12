using MathParser.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Types;

namespace MathParser.ParseTree
{
	public class NodeOperatorNegative : NodeOperatorUnary
	{
		public override TokenTypeOperator Operator
		{ get { return TokenTypes.OperatorMinus as TokenTypeOperator; } }

		public override MathType Type
		{ get { return MathType.Real; } }

		public NodeOperatorNegative(NodeBase operand) : base(operand)
		{ }

		public override IResultValue Evaluate()
		{
			return new ResultNumberReal(-1.0m * Operand.Evaluate().ToDecimal());
		}
	}
}
