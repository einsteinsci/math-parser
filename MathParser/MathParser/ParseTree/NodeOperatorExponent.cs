using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.Tokens;
using MathPlusLib;

namespace MathParser.ParseTree
{
	public class NodeOperatorExponent : NodeOperatorBinary
	{
		public override TokenClass Operator
		{ get { return TokenClass.OperatorExponent; } }

		public override MathType Type
		{ get { return MathType.Real; } }

		public override string StringForm
		{ get { return "^"; } }

		public NodeOperatorExponent(NodeFactor first, NodeFactor second) :
			base(first, second)
		{ }

		public override IResultValue GetResult()
		{
			return new ResultNumberReal(MathPlus.Pow(First.GetResult().ToDouble(), Second.GetResult().ToDouble()));
		}
	}
}
