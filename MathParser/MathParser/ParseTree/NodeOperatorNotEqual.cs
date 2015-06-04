using MathParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathPlusLib.Extensions;

namespace MathParser.ParseTree
{
	public class NodeOperatorNotEqual : NodeOperatorBinary
	{
		public override string StringForm
		{ get { return "~="; } }

		public override TokenClass Operator
		{ get { return TokenClass.OperatorNotEqual; } }

		public override MathType Type
		{ get { return MathType.Boolean; } }

		public NodeOperatorNotEqual(NodeFactor first, NodeFactor second) :
			base(first, second)
		{ }

		public override IResultValue GetResult()
		{
			IResultValue num1 = First.GetResult();
			IResultValue num2 = Second.GetResult();

			return new ResultBoolean(!num1.ToDouble().AlmostEqualTo(num2.ToDouble()));
		}
	}
}
