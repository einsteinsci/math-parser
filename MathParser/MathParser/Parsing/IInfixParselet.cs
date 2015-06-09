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
	/// Interface describing an infix syntax. All syntaxes that
	/// involve suffixes, infix operators, or mixfix operators 
	/// impelement this interface.
	/// </summary>
	public interface IInfixParselet
	{
		/// <summary>
		/// Precedence level of syntax when parsing it
		/// </summary>
		Precedence PrecedenceLevel
		{ get; }

		/// <summary>
		/// Recursive parse function for the syntax. Call parser.Parse()
		/// to continue parsing the next node, and call parser.Consume()
		/// to expect a token as part of the syntax.
		/// </summary>
		/// <param name="parser">Parser object used in recursion</param>
		/// <param name="left">Left side of syntax, already parsed</param>
		/// <param name="token">Identifying token in parsing</param>
		/// <returns>A new node merging all parts of the syntax</returns>
		NodeBase Parse(Parser parser, NodeBase left, Token token);
	}
}
