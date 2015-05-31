using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[MakeTokenClass("operatorMultiply")]
	public class TokenClassOperatorMultiply : TokenClassOperator
	{
		public override string Operator
		{ get { return "*"; } }

		public override int PrecedenceLevel
		{ get { return Precedence.MULTIPLICATIVE; } }

		public override NodeFactor MakeFactor(NodeFactor[] args)
		{
			return new NodeOperatorMultiply(args[0], args[1]);
		}
	}
}
