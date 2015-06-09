
using MathParser.ParseTree;
using MathParser.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Lexing;
using MathParser.Types;

namespace MathParser.Parsing
{
	public sealed class NumberParselet : IPrefixParselet
	{
		public NodeBase Parse(Parser parser, Token token)
		{
			long n = -1;
			if (long.TryParse(token.Lexeme, out n))
			{
				return new NodeLiteral(new ResultNumberInteger(n));
			}
			else
			{
				return new NodeLiteral(new ResultNumberReal(double.Parse(token.Lexeme)));
			}
		}
	}
}
