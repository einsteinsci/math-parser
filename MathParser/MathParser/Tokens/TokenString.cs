using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[MakeToken("string")]
	public class TokenString : TokenLiteral
	{
		public override bool SingleChar
		{ get { return false; } }

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
