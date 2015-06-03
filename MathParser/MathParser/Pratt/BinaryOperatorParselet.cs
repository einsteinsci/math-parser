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
	public class BinaryOperatorParselet : IInfixParselet
	{
		public int Precedence
		{ get; protected set; }

		public bool RightAssociative
		{ get; protected set; }

		public BinaryOperatorParselet(int precedence, bool rightAssociative)
		{
			Precedence = precedence;
			RightAssociative = rightAssociative;
		}

		public NodeFactor Parse(PrattParser parser, NodeFactor left, Token token)
		{
			NodeFactor right = parser.Parse(RightAssociative ? Precedence - 1 : Precedence);
			return BinaryInfixRegistry.MakeNode(token.Class, left, right);

			//return MakeNode(token.Class as TokenClassOperator, left, right);
		}

		// TODO: Make this load via reflection or something, for extensibility
		[Obsolete]
		public NodeOperatorBinary MakeNode(TokenClassOperator op, 
			NodeFactor left, NodeFactor right)
		{
			if (op == TokenClass.OperatorPlus)
			{
				return new NodeOperatorPlus(left, right);
			}
			else if (op == TokenClass.OperatorMinus)
			{
				return new NodeOperatorMinus(left, right);
			}
			else if (op == TokenClass.OperatorMultiply)
			{
				return new NodeOperatorMultiply(left, right);
			}
			else if (op == TokenClass.OperatorDivide)
			{
				return new NodeOperatorDivide(left, right);
			}
			else if (op == TokenClass.OperatorExponent)
			{
				return new NodeOperatorExponent(left, right);
			}
			else
			{
				throw new MismatchedRuleException(
					"Not a valid infix operator (yet): " + op.ToString());
			}
		}
	}
}
