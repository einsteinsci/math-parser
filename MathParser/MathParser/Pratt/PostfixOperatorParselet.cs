using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Lexing;
using MathParser.ParseTree;
using MathParser.Tokens;

namespace MathParser.Pratt
{
	public class PostfixOperatorParselet : IInfixParselet
	{
		public int Precedence
		{ get; private set; }

		public PostfixOperatorParselet(int precedence)
		{
			Precedence = precedence;
		}

		public NodeFactor Parse(PrattParser parser, NodeFactor left, Token token)
		{
			return MakePostfix(token.Class as TokenClassOperator, left);
		}

		public NodeOperatorUnary MakePostfix(TokenClassOperator op, NodeFactor operand)
		{
			if (op == TokenClass.OperatorFactorial)
			{
				return new NodeOperatorFactorial(operand);
			}
			else
			{
				throw new Rules.MismatchedRuleException(
					"Not a valid postfix unary operator: " + op.ToString());
			}
		}
	}
}
