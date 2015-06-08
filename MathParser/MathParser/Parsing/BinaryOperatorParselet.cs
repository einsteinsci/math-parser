using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Lexing;

namespace MathParser.Parsing
{
	public class BinaryOperatorParselet : IInfixParselet
	{
		public Precedence PrecedenceLevel
		{ get; protected set; }

		public bool RightAssociative
		{ get; protected set; }

		public BinaryOperatorParselet(Precedence precedence, bool rightAssociative)
		{
			PrecedenceLevel = precedence;
			RightAssociative = rightAssociative;
		}

		public NodeBase Parse(PrattParser parser, NodeBase left, Token token)
		{
			NodeBase right = parser.Parse(RightAssociative ? PrecedenceLevel - 1 : PrecedenceLevel);
			return BinaryInfixRegistry.MakeNode(token.Type, left, right);
		}
	}
}
