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
	public sealed class PrattParser
	{
		public Dictionary<TokenClass, IPrefixParselet> PrefixParselets
		{ get; private set; }

		public Dictionary<TokenClass, IInfixParselet> InfixParselets
		{ get; private set; }

		public TokenStream Stream
		{ get; private set; }

		List<Token> readTokens = new List<Token>();

		public PrattParser(TokenStream stream)
		{
			Stream = stream;
			Init();
		}

		public void Init()
		{
			PrefixParselets = new Dictionary<TokenClass, IPrefixParselet>();

			PrefixParselets.Add(TokenClass.Identifier, new NameParselet());
			RegisterPrefix(TokenClass.OperatorNot);
			RegisterPrefix(TokenClass.OperatorNegative);
			RegisterPrefix(TokenClass.OperatorMinus);

			InfixParselets = new Dictionary<TokenClass, IInfixParselet>();

			RegisterBinary(TokenClass.OperatorPlus, Precedence.ADDITIVE);
			RegisterBinary(TokenClass.OperatorMinus, Precedence.ADDITIVE);
			RegisterBinary(TokenClass.OperatorMultiply, Precedence.MULTIPLICATIVE);
			RegisterBinary(TokenClass.OperatorDivide, Precedence.MULTIPLICATIVE);

			RegisterPostfix(TokenClass.OperatorFactorial, Precedence.POSTFIX);
		}

		private void RegisterPrefix(TokenClass opToken)
		{
			PrefixParselets.Add(opToken, new PrefixOperatorParselet(Precedence.PREFIX));
		}

		private void RegisterBinary(TokenClass opToken, int precedence, 
			bool rightAssociative = false)
		{
			InfixParselets.Add(opToken, new BinaryOperatorParselet(precedence, rightAssociative));
		}

		private void RegisterPostfix(TokenClass opToken, int precedence)
		{
			InfixParselets.Add(opToken, new PostfixOperatorParselet(precedence));
		}

		// Pratt Parser (http://journal.stuffwithstuff.com/2011/03/19/pratt-parsers-expression-parsing-made-easy/)
		// TODO: Add the damn parentheses back in. And functions. And assignments.
		public NodeFactor Parse(int precedence = 0)
		{
			Token token = Consume();
			IPrefixParselet prefix = GetPrefix(token.Class);

			if (prefix == null)
			{
				throw new MismatchedRuleException("Could not parse: " + token.ToString());
			}

			NodeFactor left = prefix.Parse(this, token);

			while (precedence < GetPrecedence())
			{
				token = Consume();

				IInfixParselet infix = GetInfix(token.Class);
				left = infix.Parse(this, left, token);
			}

			return left;
		}

		public IPrefixParselet GetPrefix(TokenClass tokenClass)
		{
			if (PrefixParselets.ContainsKey(tokenClass))
			{
				return PrefixParselets[tokenClass];
			}

			return null;
		}

		public IInfixParselet GetInfix(TokenClass tokenClass)
		{
			if (InfixParselets.ContainsKey(tokenClass))
			{
				return InfixParselets[tokenClass];
			}

			return null;
		}

		public int GetPrecedence()
		{
			Token ahead = LookAhead();
			if (ahead == null)
			{
				return 0;
			}

			IInfixParselet parselet = GetInfix(ahead.Class);
			if (parselet != null)
			{
				return parselet.Precedence;
			}

			return 0;
		}

		private Token Consume()
		{
			LookAhead();

			Token rem = readTokens[0];
			readTokens.RemoveAt(0);
			return rem;
		}

		private Token LookAhead(int distance = 0)
		{
			while (distance >= readTokens.Count)
			{
				Token next = Stream.Next();

				if (next == null)
				{
					return null;
				}

				readTokens.Add(next);
			}

			return readTokens[distance];
		}
	}
}
