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
		public override string StringForm
		{ get { return "!"; } }

		public override TokenType Operator
		{ get { return TokenType.OperatorFactorial; } }

		public override MathType Type
		{ get { return MathType.Integer; } }

		public NodeOperatorFactorial(NodeBase operand) : base(operand)
		{ }

		public override IResultValue Evaluate()
		{
			IResultValue res = Operand.Evaluate();

			if (!res.ToDouble().IsInteger(8))
			{
				throw new EvaluationException(this,
					"Cannot use floating-point types in factorial calculation.");
			}

			return new ResultNumberReal(MathPlus.Probability.Factorial(res.ToInteger()));
		}

		public override string ToString()
		{
			return "(" + Operand.ToString() + "!)";
		}
	}
}
