using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Lexing;

namespace MathParser.Parsing
{
	public interface IInfixParselet
	{
		Precedence PrecedenceLevel
		{ get; }

		NodeFactor Parse(PrattParser parser, NodeFactor left, Token token);
	}
}
