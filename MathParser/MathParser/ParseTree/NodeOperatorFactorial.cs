using MathParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathPlusLib;

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
			return new ResultNumberReal(MathPlus.Probability.Factorial((long)Term.GetResult().ToDouble()));
		}

		public override string ToString()
		{
			return "(" + Term.ToString() + "!)";
		}
	}
}
