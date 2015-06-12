using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Parsing;

namespace MathParser.Lexing
{
	/// <summary>
	/// Base class from which all operator tokens are derived from
	/// </summary>
	public abstract class TokenTypeOperator : TokenType
	{
		/// <summary>
		/// Lexer priority level for operators. Reference as necessary.
		/// </summary>
		public const int PRIORITY = 4;

		/// <summary>
		/// String representing the operator itself. "+", for example.
		/// </summary>
		public abstract string StringForm
		{ get; }

		/// <summary>
		/// Value of lexer priority. Defaults to PRIORITY (defined above).
		/// </summary>
		public override int LexerPriority
		{ get { return PRIORITY; } }

		/// <summary>
		/// True if the operator is right-associative
		/// </summary>
		public virtual bool IsRightAssociative
		{ get { return false; } }

		/// <summary>
		/// Returns true if the operator exactly matches the given lexeme.
		/// </summary>
		/// <param name="lexeme">String to check against the operator</param>
		/// <returns>True if the operator matches the lexeme, false if not.</returns>
		public override bool Matches(string lexeme)
		{
			return lexeme == StringForm;
		}

		/// <summary>
		/// Converts the token type to a string.
		/// </summary>
		public override string ToString()
		{
			return "[Operator" + StringForm + "]";
		}
	}
}
