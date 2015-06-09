using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Lexing;
using MathParser.Parsing;

namespace MathParser.Test
{
	[BinaryOperator(DOLLAR, typeof(NodeStringRepeat), Precedence.MULTIPLICATIVE)]
	[TokenType(DOLLAR)]
	public class TokenTypeDollar : TokenTypeOperator
	{
		const string DOLLAR = "operatorDollar";

		public static TokenType Instance
		{ get { return TokenTypeRegistry.Get(DOLLAR); } }

		public override string Operator
		{ get { return "$"; } }
	}
}
