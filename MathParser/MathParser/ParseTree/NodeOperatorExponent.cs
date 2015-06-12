using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.Lexing;
using MathPlusLib;
using MathParser.Types;

namespace MathParser.ParseTree
{
	public class NodeOperatorExponent : NodeOperatorBinary
	{
		public override TokenTypeOperator Operator
		{ get { return TokenTypes.OperatorExponent as TokenTypeOperator; } }

		public override MathType Type
		{ get { return MathType.Real; } }
		
		public NodeOperatorExponent(NodeBase first, NodeBase second) :
			base(first, second)
		{ }

		public override IResultValue Evaluate()
		{
			return new ResultNumberReal(MathPlus.Pow((double)First.Evaluate().ToDecimal(), (double)Second.Evaluate().ToDecimal()));
		}
	}
}
