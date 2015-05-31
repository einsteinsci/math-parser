using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[MakeTokenClass("operatorNotEqual")]
	public class TokenClassOperatorNotEqual : TokenClassOperator
	{
		public override string Operator
		{ get { return "<>"; } }

		public override int PrecedenceLevel
		{ get { return Precedence.EQUALITY; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorNotEqual(args[0], args[1]);
		}
	}
}
