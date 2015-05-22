using MathParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathPlusLib.Extensions;

namespace MathParser.ParseTree
{
	public class NodeOperatorBitShiftRight : NodeOperatorBinary
	{
		public override string StringForm
		{ get { return ">>"; } }

		public override Token Operator
		{ get { return Token.OperatorBitShiftLeft; } }

		public override MathType Type
		{ get { return MathType.Integer; } }

		public NodeOperatorBitShiftRight(NodeFactor first, NodeFactor second)
		{
			First = first;
			Second = second;
		}

		public override IResultValue GetResult()
		{
			IResultValue res1 = First.GetResult();
			IResultValue res2 = Second.GetResult();

			if (!res1.ToDouble().IsInteger(8))
			{
				throw new ArgumentOutOfRangeException("[FIELD]:First",
					"Cannot use floating-point types in bit-shift calculations.");
			}
			if (!res2.ToDouble().IsInteger(8))
			{
				throw new ArgumentOutOfRangeException("[FIELD]:Second",
					"Cannot use floating-point types in bit-shift calculations.");
			}

			return new ResultNumberInteger((int)res1.ToInteger() >> (int)res2.ToInteger());
		}
	}
}
