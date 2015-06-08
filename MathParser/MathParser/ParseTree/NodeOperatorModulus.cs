using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.Lexing;
using MathParser.Types;
using MathPlusLib.Extensions;

namespace MathParser.ParseTree
{
	public class NodeOperatorModulus : NodeOperatorBinary
	{
		public override TokenType Operator
		{
			get { return TokenType.OperatorModulus; }
		}

		public override MathType Type
		{ get { return MathType.Integer; } }

		public override string StringForm
		{ get { return "%"; } }

		public NodeOperatorModulus(NodeBase first, NodeBase second) :
			base(first, second)
		{ }

		public override IResultValue Evaluate()
		{
			IResultValue res1 = First.Evaluate();
			IResultValue res2 = Second.Evaluate();

			if (!res1.ToDouble().IsInteger(8) || !res2.ToDouble().IsInteger(8))
			{
				throw new EvaluationException(this, 
					"Cannot use floating-point types in modulus calculation.");
			}

			return new ResultNumberReal(res1.ToInteger() % res2.ToInteger());
		}
	}
}
