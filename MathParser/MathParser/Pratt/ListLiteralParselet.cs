using MathParser.Lexing;
using MathParser.Tokens;
using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Pratt
{
	public class ListLiteralParselet : IPrefixParselet
	{
		public NodeFactor Parse(PrattParser parser, Token token)
		{
			List<NodeFactor> elements = new List<NodeFactor>();

			if (!parser.Match(TokenClass.BraceOut))
			{
				do
				{
					elements.Add(parser.Parse());
				}
				while (parser.Match(TokenClass.Comma));

				parser.Consume(TokenClass.BraceOut);
			}

			return new NodeListLiteral(elements);
		}
	}
}
