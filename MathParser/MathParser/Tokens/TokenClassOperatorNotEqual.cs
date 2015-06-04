using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Pratt;

namespace MathParser.Tokens
{
	[BinaryOperator("operatorNotEqual", typeof(NodeOperatorNotEqual), Precedence.EQUALITY)]
	[MakeTokenClass("operatorNotEqual")]
	public class TokenClassOperatorNotEqual : TokenClassOperator
	{
		public override string Operator
		{ get { return "~="; } }
	}
}
