using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.Lexing;

namespace MathParser.Lexing
{
	/// <summary>
	/// A specific token created from the input string
	/// </summary>
	public class Token
	{
		/// <summary>
		/// Type of token
		/// </summary>
		public TokenType Type
		{ get; internal set; }

		/// <summary>
		/// Lexeme containing original string turned into token
		/// </summary>
		public string Lexeme
		{ get; protected set; }

		/// <summary>
		/// Instantiates a new Token
		/// </summary>
		public Token(TokenType token, string lexed)
		{
			Type = token;
			Lexeme = lexed;
		}

		public override string ToString()
		{
			return "{" + Type.ToString() + ":'" + Lexeme + "'}";
		}
	}
}
