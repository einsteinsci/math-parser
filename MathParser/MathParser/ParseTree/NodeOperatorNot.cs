using MathParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	public class NodeOperatorNot : NodeOperatorUnary
	{
		public override string StringForm
		{ get { return "~"; } }

		public override TokenClass Operator
		{ get { return TokenClass.OperatorNot; } }

		public override MathType Type
		{ get { return MathType.Boolean; } }

		public NodeOperatorNot(NodeFactor term)
		{
			Term = term;
		}

		public override IResultValue GetResult()
		{
			return new ResultBoolean(!Term.GetResult().ToBoolean());
		}
	}
}
