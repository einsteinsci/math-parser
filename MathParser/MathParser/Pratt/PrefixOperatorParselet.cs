using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Lexing;
using MathParser.ParseTree;
using MathParser.Rules;
using MathParser.Tokens;

namespace MathParser.Pratt
{
	public class PrefixOperatorParselet : IPrefixParselet
	{
		public int Precedence
		{ get; protected set; }

		public PrefixOperatorParselet(int precedence)
		{
			Precedence = precedence;
		}

		public NodeFactor Parse(PrattParser parser, Token token)
		{
			NodeFactor operand = parser.Parse(Precedence);
			return MakeNode(token.Class as TokenClassOperator, operand);
		}

		public NodeOperatorUnary MakeNode(TokenClassOperator op, NodeFactor operand)
		{
			if (op == TokenClass.OperatorNot)
			{
				return new NodeOperatorNot(operand);
			}
			else if (op == TokenClass.OperatorNegative || op == TokenClass.OperatorMinus)
			{
				return new NodeOperatorNegative(operand);
			}
			else
			{
				throw new MismatchedRuleException(
					"Not a valid unary prefix operator: " + op.ToString());
			}
		}
	}
}
