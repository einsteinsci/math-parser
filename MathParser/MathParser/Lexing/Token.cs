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
		public TokenType Class
		{ get; internal set; }

		public string Lexed
		{ get; protected set; }

		public Token(TokenType token, string lexed)
		{
			Class = token;
			Lexed = lexed;
		}

		public override string ToString()
		{
			return "{" + Class.ToString() + ":'" + Lexed + "'}";
		}
	}
}
