
using MathParser.Lexing;
using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Parsing
{
	public class ListLiteralParselet : IPrefixParselet
	{
		public NodeBase Parse(Parser parser, Token token)
		{
			List<NodeBase> elements = new List<NodeBase>();

			if (!parser.Match(TokenTypes.BraceOut))
			{
				do
				{
					elements.Add(parser.Parse());
				}
				while (parser.Match(TokenTypes.Comma));

				parser.Consume(TokenTypes.BraceOut);
			}

			return new NodeListLiteral(elements);
		}
	}
}
