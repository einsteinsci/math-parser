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
	/// Parselet for parsing binary operators. 
	/// </summary>
	public sealed class BinaryOperatorParselet : IInfixParselet
	{
		/// <summary>
		/// Precedence level defined by operator
		/// </summary>
		public Precedence PrecedenceLevel
		{ get; private set; }

		/// <summary>
		/// True if the operator is right-associative, false if not
		/// </summary>
		public bool RightAssociative
		{ get; private set; }

		/// <summary>
		/// Instantiates a new BinaryOperatorParselet
		/// </summary>
		public BinaryOperatorParselet(Precedence precedence, bool rightAssociative)
		{
			PrecedenceLevel = precedence;
			RightAssociative = rightAssociative;
		}
		
		/// <summary>
		/// Parses an expression with the parser through recursion
		/// </summary>
		/// <param name="parser">Parser to continue recursion</param>
		/// <param name="left">Already-parsed left side of operator</param>
		/// <param name="token">Identifying token for operator</param>
		/// <returns></returns>
		public NodeBase Parse(Parser parser, NodeBase left, Token token)
		{
			NodeBase right = parser.Parse(RightAssociative ? PrecedenceLevel - 1 : PrecedenceLevel);
			return BinaryInfixRegistry.MakeNode(token.Type, left, right);
		}
	}
}
