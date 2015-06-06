
using MathParser.ParseTree;
using MathParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Tokens;
using MathParser.Types;

namespace MathParser.Pratt
{
	public sealed class NumberParselet : IPrefixParselet
	{
		public NodeFactor Parse(PrattParser parser, Token token)
		{
			long n = -1;
			if (long.TryParse(token.Lexed, out n))
			{
				return new NodeLiteral(new ResultNumberInteger(n));
			}
			else
			{
				return new NodeLiteral(new ResultNumberReal(double.Parse(token.Lexed)));
			}
		}
	}
}
