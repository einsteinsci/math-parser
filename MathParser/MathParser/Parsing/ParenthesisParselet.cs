
using MathParser.ParseTree;
using MathParser.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Parsing
{
	public class ParenthesisParselet : IPrefixParselet
	{
		public NodeFactor Parse(PrattParser parser, Token token)
		{
			NodeFactor node = parser.Parse();
			parser.Consume(TokenType.ParenthesisOut);

			return node;
		}
	}
}
