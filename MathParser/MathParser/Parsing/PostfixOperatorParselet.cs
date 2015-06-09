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
	/// Parselet for parsing postfix unary operators
	/// </summary>
	public class PostfixOperatorParselet : IInfixParselet
	{
		/// <summary>
		/// Precedence level of parselet. Almost always set to
		/// Precedence.POSTFIX.
		/// </summary>
		public Precedence PrecedenceLevel
		{ get; private set; }

		/// <summary>
		/// Instantiates the parselet for the registry.
		/// </summary>
		public PostfixOperatorParselet(Precedence precedence)
		{
			PrecedenceLevel = precedence;
		}

		/// <summary>
		/// Recursive parse function for parselet
		/// </summary>
		/// <param name="parser">Parser for continued parsing. Ignored.</param>
		/// <param name="left">Pre-parsed left side of operator.</param>
		/// <param name="token">Identifying token in parselet.</param>
		/// <returns></returns>
		public NodeBase Parse(Parser parser, NodeBase left, Token token)
		{
			return UnaryPostfixRegistry.MakeNode(token.Type, left);
		}
	}
}
