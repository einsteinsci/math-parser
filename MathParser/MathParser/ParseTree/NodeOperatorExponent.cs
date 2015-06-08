using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.Lexing;
using MathPlusLib;
using MathParser.Types;

namespace MathParser.ParseTree
{
	public class NodeOperatorExponent : NodeOperatorBinary
	{
		public override TokenType Operator
		{ get { return TokenType.OperatorExponent; } }

		public override MathType Type
		{ get { return MathType.Real; } }

		public override string StringForm
		{ get { return "^"; } }

		public NodeOperatorExponent(NodeBase first, NodeBase second) :
			base(first, second)
		{ }

		public override IResultValue Evaluate()
		{
			return new ResultNumberReal(MathPlus.Pow(First.Evaluate().ToDouble(), Second.Evaluate().ToDouble()));
		}
	}
}
