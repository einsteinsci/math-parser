using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Lexing;
using MathParser.ParseTree;
using MathParser.Types;

namespace MathParser.Test
{
	public class NodeStringRepeat : NodeOperatorBinary
	{
		public override TokenTypeOperator Operator
		{ get { return TokenTypeDollar.Instance as TokenTypeOperator; } }

		public override string StringForm
		{ get { return "$"; } }

		public override MathType Type
		{ get { return MathType.String; } }

		public NodeStringRepeat(NodeBase first, NodeBase second) : base(first, second)
		{ }

		public override IResultValue Evaluate()
		{
			string str = First.Evaluate().ToString();
			IResultValue countIRV = Second.Evaluate();
			if (countIRV.Type != MathType.Integer)
			{
				throw new EvaluationException("That's no integer....");
			}
			int count = (int)countIRV.ToInteger();
			string res = "";
			for (int i = 0; i < count; i++)
			{
				res += str;
			}

			return new ResultString(res);
		}
	}
}
