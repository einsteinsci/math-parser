
using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Lexing;
using MathParser.Types;

namespace MathParser.Parsing
{
	public class StringParselet : IPrefixParselet
	{
		public NodeFactor Parse(PrattParser parser, Token token)
		{
			string str = token.Lexed.TrimEnd('"').TrimStart('"');
			return new NodeLiteral(new ResultString(str));
		}
	}
}
