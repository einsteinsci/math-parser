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
		public override TokenTypeOperator Operator
		{ get { return TokenTypes.OperatorNotEqual as TokenTypeOperator; } }

		public override MathType Type
		{ get { return MathType.Boolean; } }

		public NodeOperatorNotEqual(NodeBase first, NodeBase second) :
			base(first, second)
		{ }

		public override IResultValue Evaluate()
		{
			IResultValue num1 = First.Evaluate();
			IResultValue num2 = Second.Evaluate();

			double d1 = (double)num1.ToDecimal();
			double d2 = (double)num2.ToDecimal();

			return new ResultBoolean(!d1.AlmostEqualTo(d2));
		}
	}
}
