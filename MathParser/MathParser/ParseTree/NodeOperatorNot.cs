using MathParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Types;

namespace MathParser.ParseTree
{
	public class NodeOperatorNot : NodeOperatorUnary
	{
		public override string StringForm
		{ get { return "~"; } }

		public override TokenType Operator
		{ get { return TokenType.OperatorNot; } }

		public override MathType Type
		{ get { return MathType.Boolean; } }

		public NodeOperatorNot(NodeFactor operand) : base(operand)
		{ }

		public override IResultValue GetResult()
		{
			return new ResultBoolean(!Operand.GetResult().ToBoolean());
		}
	}
}
