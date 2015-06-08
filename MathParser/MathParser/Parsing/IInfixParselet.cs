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

		NodeBase Parse(PrattParser parser, NodeBase left, Token token);
	}
}
