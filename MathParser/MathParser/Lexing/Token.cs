using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.Tokens;

namespace MathParser.Lexing
{
	public class Token
	{
		public TokenClass Token
		{ get; internal set; }

		public string Lexed
		{ get; protected set; }

		public TokenType Type
		{ get { return Token.Type; } }

		public Token(TokenClass token, string lexed)
		{
			Token = token;
			Lexed = lexed;
		}

		public override string ToString()
		{
			return "{" + Token.ToString() + ":'" + Lexed + "'}";
		}
	}
}
