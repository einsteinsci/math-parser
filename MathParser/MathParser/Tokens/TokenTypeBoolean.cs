using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Tokens;
using MathParser.Types;

namespace MathParser.Tokens
{
	[TokenType("boolean")]
	public class TokenTypeBoolean : TokenTypeLiteral
	{
		public override NodeLiteral MakeNode(string lexeme)
		{
			bool val = bool.Parse(lexeme);
			return new NodeLiteral(new ResultBoolean(val));
		}

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
