using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Lexing;
using MathParser.Types;

namespace MathParser.Lexing
{
	[TokenType("boolean")]
	public class TokenTypeBoolean : TokenTypeLiteral
	{
		public override bool Matches(string lexeme)
		{
			return lexeme.ToLower() == "false" || lexeme.ToLower() == "true";
		}

		public override string ToString()
		{
			return "[Boolean]";
		}
	}
}
