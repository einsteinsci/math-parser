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
		public TokenClass Class
		{ get; internal set; }

		public string Lexed
		{ get; protected set; }

		public TokenType Type
		{ get { return Class.Type; } }

		public Token(TokenClass token, string lexed)
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
