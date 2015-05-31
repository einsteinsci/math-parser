using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Lexing;
using MathParser.ParseTree;

namespace MathParser.Pratt
{
	public interface IPrefixParselet
	{
		NodeFactor Parse(PrattParser parser, Token token);
	}
}
