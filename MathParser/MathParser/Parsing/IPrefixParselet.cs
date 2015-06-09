using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.ParseTree;
using MathParser.Lexing;

namespace MathParser.Parsing
{
	/// <summary>
	/// Interface describing a prefix syntax. All syntaxes that
	/// identitfy themselves by their starting token (including parenthesis
	/// groups) implement this interface.
	/// </summary>
	public interface IPrefixParselet
	{
		/// <summary>
		/// Recursive parse function for the syntax. Call parser.Parse()
		/// to continue parsing the next node, and call parser.Consume()
		/// to expect a token as part of the syntax.
		/// </summary>
		/// <param name="parser">Parser used in recursion</param>
		/// <param name="token">Identifying token in the parselet</param>
		/// <returns>
		///   A new node from all the child nodes parsed 
		///   by this parselet.
		/// </returns>
		NodeBase Parse(Parser parser, Token token);
	}
}
