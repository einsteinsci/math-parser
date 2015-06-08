using MathParser.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Types;

using MathPlusLib.Extensions;

namespace MathParser.ParseTree
{
	public class NodeOperatorNotEqual : NodeOperatorBinary
	{
		public override string StringForm
		{ get { return "~="; } }

		public override TokenType Operator
		{ get { return TokenType.OperatorNotEqual; } }

		public override MathType Type
		{ get { return MathType.Boolean; } }

		public NodeOperatorNotEqual(NodeBase first, NodeBase second) :
			base(first, second)
		{ }

		public override IResultValue Evaluate()
		{
			IResultValue num1 = First.Evaluate();
			IResultValue num2 = Second.Evaluate();

			return new ResultBoolean(!num1.ToDouble().AlmostEqualTo(num2.ToDouble()));
		}
	}
}
