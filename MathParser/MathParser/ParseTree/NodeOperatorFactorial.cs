using MathParser.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathPlusLib;
using MathPlusLib.Extensions;
using MathParser.Types;

namespace MathParser.ParseTree
{
	public class NodeOperatorFactorial : NodeOperatorUnary
	{
		public override TokenTypeOperator Operator
		{ get { return TokenTypes.OperatorFactorial as TokenTypeOperator; } }

		public override MathType Type
		{ get { return MathType.Integer; } }

		public NodeOperatorFactorial(NodeBase operand) : base(operand)
		{ }

		public override IResultValue Evaluate()
		{
			IResultValue res = Operand.Evaluate();

			if (!((double)res.ToDecimal()).IsInteger(8))
			{
				throw new EvaluationException(this,
					"Cannot use floating-point types in factorial calculation.");
			}

			return new ResultNumberReal((decimal)MathPlus.Probability.Factorial(res.ToInteger()));
		}

		public override string ToString()
		{
			return "(" + Operand.ToString() + "!)";
		}
	}
}
