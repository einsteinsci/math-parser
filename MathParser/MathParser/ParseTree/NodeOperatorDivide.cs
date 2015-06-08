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
		public override TokenType Operator
		{ get { return TokenType.OperatorDivide; } }

		public override MathType Type
		{ get { return MathType.Real; } }

		public override string StringForm
		{ get { return "/"; } }

		public NodeOperatorDivide(NodeBase first, NodeBase second) :
			base(first, second)
		{ }

		public override IResultValue Evaluate()
		{
			return new ResultNumberReal(First.Evaluate().ToDouble() / Second.Evaluate().ToDouble());
		}
	}
}
