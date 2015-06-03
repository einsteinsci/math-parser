using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[BinaryOperator("operatorEqual", typeof(NodeOperatorEqual), Precedence.EQUALITY)]
	[MakeTokenClass("operatorEqual")]
	public class TokenClassOperatorEqual : TokenClassOperator
	{
		public override string Operator
		{ get { return "=="; } }

		public override int PrecedenceLevel
		{ get { return Precedence.EQUALITY; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorEqual(args[0], args[1]);
		}
	}
}
