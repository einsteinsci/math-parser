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
		public override TokenTypeOperator Operator
		{
			get { return TokenTypes.OperatorModulus as TokenTypeOperator; }
		}

		public override MathType Type
		{ get { return MathType.Integer; } }

		public NodeOperatorModulus(NodeBase first, NodeBase second) :
			base(first, second)
		{ }

		public override IResultValue Evaluate()
		{
			IResultValue res1 = First.Evaluate();
			IResultValue res2 = Second.Evaluate();

			if (!((double)res1.ToDecimal()).IsInteger(8) || !((double)res2.ToDecimal()).IsInteger(8))
			{
				throw new EvaluationException(this, 
					"Cannot use floating-point types in modulus calculation.");
			}

			return new ResultNumberReal((decimal)(res1.ToInteger() % res2.ToInteger()));
		}
	}
}
