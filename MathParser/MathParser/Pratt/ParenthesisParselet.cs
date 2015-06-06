
using MathParser.ParseTree;
using MathParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Pratt
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
