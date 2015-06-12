using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Parsing;

namespace MathParser.Lexing
{
	[PrefixOperator("operatorNot", typeof(NodeOperatorNot))]
	[TokenType("operatorNot")]
	public class TokenTypeOperatorNot : TokenTypeOperator
	{
		public override string StringForm
		{ get { return "~"; } }
	}
}
