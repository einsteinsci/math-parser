using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.ParseTree;
using MathParser.Lexing;

namespace MathParser.Parsing
{
	public class PrefixOperatorParselet : IPrefixParselet
	{
		public Precedence Precedence
		{ get; protected set; }

		public PrefixOperatorParselet(Precedence precedence)
		{
			Precedence = precedence;
		}

		public NodeFactor Parse(PrattParser parser, Token token)
		{
			NodeFactor operand = parser.Parse(Precedence);
			return UnaryPrefixRegistry.MakeNode(token.Class, operand);
		}
	}
}
