
using MathParser.ParseTree;
using MathParser.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Parsing
{
	public class ConditionalParselet : IInfixParselet
	{
		public Precedence PrecedenceLevel
		{ get { return Precedence.CONDITIONAL_TERNARY; } }

		public NodeFactor Parse(PrattParser parser, NodeFactor left, Token token)
		{
			NodeFactor onTrue = parser.Parse();
			parser.Consume(TokenType.OperatorColon);
			NodeFactor onFalse = parser.Parse();

			return new NodeOperatorConditional(left, onTrue, onFalse);
		}
	}
}
