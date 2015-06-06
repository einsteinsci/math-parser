using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.Tokens;
using MathPlusLib.Extensions;

namespace MathParser.ParseTree
{
	public class NodeOperatorModulus : NodeOperatorBinary
	{
		public override TokenClass Operator
		{
			get { return TokenClass.OperatorModulus; }
		}

		public override MathType Type
		{ get { return MathType.Integer; } }

		public override string StringForm
		{ get { return "%"; } }

		public NodeOperatorModulus(NodeFactor first, NodeFactor second) :
			base(first, second)
		{ }

		public override IResultValue GetResult()
		{
			IResultValue res1 = First.GetResult();
			IResultValue res2 = Second.GetResult();

			if (!res1.ToDouble().IsInteger(8) || !res2.ToDouble().IsInteger(8))
			{
				throw new EvaluationException(this, 
					"Cannot use floating-point types in modulus calculation.");
			}

			return new ResultNumberReal(res1.ToInteger() % res2.ToInteger());
		}
	}
}
