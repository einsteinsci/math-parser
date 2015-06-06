using MathParser.ParseTree;
using MathParser.Tokens;
using MathParser.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[TokenType("string")]
	public class TokenTypeString : TokenTypeLiteral
	{
		public override bool Matches(string lexeme)
		{
			return lexeme.StartsWith("\"") && lexeme.EndsWith("\"") && lexeme.Length > 2;
		}

		public override NodeLiteral MakeNode(string lexeme)
		{
			string buf = lexeme.TrimEnd('"').TrimStart('"');
			return new NodeLiteral(new ResultString(buf));
		}

		public override string ToString()
		{
			return "[String]";
		}
	}
}
