using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.Lexing;
using MathParser.Types;

namespace MathParser.ParseTree
{
	public class NodeOperatorMultiply : NodeOperatorBinary
	{
		public override TokenTypeOperator Operator
		{
			get { return TokenTypes.OperatorMultiply as TokenTypeOperator; }
		}

		public override MathType Type
		{ get { return MathType.Real; } }

		public override string StringForm
		{ get { return "*"; } }

		public NodeOperatorMultiply(NodeBase first, NodeBase second) :
			base(first, second)
		{ }

		public override IResultValue Evaluate()
		{
			return new ResultNumberReal(First.Evaluate().ToDecimal() * Second.Evaluate().ToDecimal());
		}
	}
}
