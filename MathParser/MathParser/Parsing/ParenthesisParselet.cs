
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
		public NodeBase Parse(Parser parser, Token token)
		{
			NodeBase node = parser.Parse();
			parser.Consume(TokenTypes.ParenthesisOut);

			return node;
		}
	}
}
