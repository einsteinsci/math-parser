using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.ParseTree;
using MathParser.Tokens;

namespace MathParser.Pratt
{
	public class NameParselet : IPrefixParselet
	{
		public NodeFactor Parse(PrattParser parser, Token token)
		{
			return new NodeIdentifier(token.Lexed);
		}
	}
}
