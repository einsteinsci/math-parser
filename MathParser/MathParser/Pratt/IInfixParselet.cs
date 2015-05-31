using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Lexing;
using MathParser.ParseTree;

namespace MathParser.Pratt
{
	public interface IInfixParselet
	{
		int Precedence
		{ get; }

		NodeFactor Parse(PrattParser parser, NodeFactor left, Token token);
	}
}
