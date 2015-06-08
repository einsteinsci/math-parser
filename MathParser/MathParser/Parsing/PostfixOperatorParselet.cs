using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.ParseTree;
using MathParser.Lexing;

namespace MathParser.Parsing
{
	public class PostfixOperatorParselet : IInfixParselet
	{
		public Precedence PrecedenceLevel
		{ get; private set; }

		public PostfixOperatorParselet(Precedence precedence)
		{
			PrecedenceLevel = precedence;
		}

		public NodeBase Parse(PrattParser parser, NodeBase left, Token token)
		{
			return UnaryPostfixRegistry.MakeNode(token.Type, left);
		}
	}
}
