using MathParser.Tokens;
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
		public override string StringForm
		{ get { return "-"; } }

		public override TokenType Operator
		{ get { return TokenType.OperatorMinus; } }

		public override MathType Type
		{ get { return MathType.Real; } }

		public NodeOperatorNegative(NodeFactor operand) : base(operand)
		{ }

		public override IResultValue GetResult()
		{
			return new ResultNumberReal(-1.0 * Operand.GetResult().ToDouble());
		}
	}
}
