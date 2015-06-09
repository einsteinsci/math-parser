
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
		public NodeBase Parse(Parser parser, Token token)
		{
			string str = token.Lexeme.TrimEnd('"').TrimStart('"');
			return new NodeLiteral(new ResultString(str));
		}
	}
}
