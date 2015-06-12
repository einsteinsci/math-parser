using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace MathParser.Lexing
{
	/// <summary>
	/// Base class for all types of tokens. All classes that extend
	/// this are singletons, instantiated via reflection.
	/// </summary>
	public abstract class TokenType
	{
		/// <summary>
		/// Returns true if the token matches the given lexeme,
		/// for the tokenizer.
		/// </summary>
		/// <param name="lexeme">Lexeme to check against</param>
		/// <returns>True if the this matches the lexeme, false if not</returns>
		public abstract bool Matches(string lexeme);
		
		/// <summary>
		/// Gets the lexer priority of the token. Operators are at 4. Higher numbers are
		/// further down in priority.
		/// </summary>
		public abstract int LexerPriority
		{ get; }

		/// <summary>
		/// Whether to ignore a token of this type when creating the parse tree.
		/// </summary>
		public virtual bool IgnoreInTree
		{ get { return false; } }

		/// <summary>
		/// A custom registry, if the TokenType sets the named property Custom
		/// in the applied TokenTypeAttribute. Useless otherwise.
		/// </summary>
		public virtual Dictionary<string, TokenType> CustomRegistry
		{ get { return null; } }
	}
}
