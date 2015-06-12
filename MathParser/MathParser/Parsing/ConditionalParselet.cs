
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

		public NodeBase Parse(Parser parser, NodeBase left, Token token)
		{
			NodeBase onTrue = parser.Parse();
			parser.Consume(TokenTypes.OperatorColon);
			NodeBase onFalse = parser.Parse();

			return new NodeOperatorConditional(left, onTrue, onFalse);
		}
	}
}
