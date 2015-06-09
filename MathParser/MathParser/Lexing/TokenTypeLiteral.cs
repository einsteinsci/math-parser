using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Lexing
{
	/// <summary>
	/// Base class for all tokens that represent literal values
	/// (except lists)
	/// </summary>
	public abstract class TokenTypeLiteral : TokenType
	{
		/// <summary>
		/// Priority of token in lexer
		/// </summary>
		public override int LexerPriority
		{ get { return 5; } }
	}
}
