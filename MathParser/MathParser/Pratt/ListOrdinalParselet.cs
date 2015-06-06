using MathParser.Lexing;
using MathParser.ParseTree;
using MathParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Pratt
{
	public class ListOrdinalParselet : IInfixParselet
	{
		public Precedence PrecedenceLevel
		{ get { return Precedence.PRIMARY; } }

		public NodeFactor Parse(PrattParser parser, NodeFactor left, Token token)
		{
			NodeFactor ordinal = parser.Parse();

			parser.Consume(TokenType.BracketOut);

			return new NodeListOrdinal(left, ordinal);
		}
	}
}
