using MathParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathPlusLib;
using MathPlusLib.Extensions;

namespace MathParser.ParseTree
{
	public class NodeOperatorFactorial : NodeOperatorUnary
	{
		public override string StringForm
		{ get { return "!"; } }

		public override Token Operator
		{ get { return Token.OperatorFactorial; } }

		public override MathType Type
		{ get { return MathType.Integer; } }

		public NodeOperatorFactorial(NodeFactor term)
		{
			Term = term;
		}

		public override IResultValue GetResult()
		{
			IResultValue res = Term.GetResult();

			if (!res.ToDouble().IsInteger(8))
			{
				throw new ArgumentOutOfRangeException("[FIELD]:Term",
					"Cannot use floating-point types in factorial calculation.");
			}

			return new ResultNumberReal(MathPlus.Probability.Factorial(res.ToInteger()));
		}

		public override string ToString()
		{
			return "(" + Term.ToString() + "!)";
		}
	}
}
