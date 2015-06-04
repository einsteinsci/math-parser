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
	public sealed class PrattParser
	{
		public Dictionary<TokenClass, IPrefixParselet> PrefixParselets
		{ get; private set; }

		public Dictionary<TokenClass, IInfixParselet> InfixParselets
		{ get; private set; }

		public TokenStream Stream
		{ get; private set; }

		List<Token> readTokens = new List<Token>();

		public event Action<Dictionary<TokenClass, IPrefixParselet>> PrefixLoading;
		public event Action<Dictionary<TokenClass, IInfixParselet>> InfixLoading;
		public event Action<Dictionary<TokenClass, IInfixParselet>> PostfixLoading;

		public PrattParser(TokenStream stream)
		{
			Stream = stream;
			Init();
		}

		public static NodeFactor Parse(TokenStream stream)
		{
			PrattParser inst = new PrattParser(stream);
			return inst.Parse();
		}

		public void Init()
		{
			Logger.Log(LogLevel.Debug, Logger.REGISTRY, "Starting parselet registry.");
			PrefixParselets = new Dictionary<TokenClass, IPrefixParselet>();

			Logger.Log(LogLevel.Debug, Logger.REGISTRY, "Registering prefix parselets.");
			PrefixParselets.Add(TokenClass.Identifier, new NameParselet());
			PrefixParselets.Add(TokenClass.Number, new NumberParselet());
			PrefixParselets.Add(TokenClass.String, new StringParselet());
			PrefixParselets.Add(TokenClass.Boolean, new BooleanParselet());

			PrefixParselets.Add(TokenClass.ParenthesisIn, new ParenthesisParselet());

			PrefixParselets.Add(TokenClass.BraceIn, new ListLiteralParselet());

			foreach (TokenClass tc in UnaryPrefixRegistry.GetTokens())
			{
				RegisterPrefixOperator(tc);
			}

			if (PrefixLoading != null)
			{
				PrefixLoading(PrefixParselets);
			}

			InfixParselets = new Dictionary<TokenClass, IInfixParselet>();

			Logger.Log(LogLevel.Debug, Logger.REGISTRY, "Registering infix and postfix parselets.");
			InfixParselets.Add(TokenClass.ParenthesisIn, new FunctionCallParselet());

			foreach (TokenClass tc in BinaryInfixRegistry.GetTokens())
			{
				BinaryInfixRegistry.RegItem reg = BinaryInfixRegistry.Get(tc);
				RegisterBinaryOperator(tc, reg.PrecedenceLevel, reg.IsRightAssociative);
			}

			foreach (TokenClass tc in UnaryPostfixRegistry.GetTokens())
			{
				RegisterPostfixOperator(tc);
			}

			if (InfixLoading != null)
			{
				InfixLoading(InfixParselets);
			}
		}

		#region register
		public void RegisterPrefix(TokenClass token, IPrefixParselet parselet)
		{
			Logger.Log(LogLevel.Debug, Logger.REGISTRY,
				"Registering prefix parselet for token " + token.ToString());
			PrefixParselets.Add(token, parselet);
		}

		public void RegisterPrefixOperator(TokenClass opToken)
		{
			Logger.Log(LogLevel.Debug, Logger.REGISTRY, 
				"Registering prefix operator parselet for token " + opToken.ToString());
			PrefixParselets.Add(opToken, new PrefixOperatorParselet(Precedence.PREFIX));
		}

		public void RegisterInfix(TokenClass token, IInfixParselet parselet)
		{
			Logger.Log(LogLevel.Debug, Logger.REGISTRY,
				"Registering infix/postfix operator parselet for token " + token.ToString());
			InfixParselets.Add(token, parselet);
		}

		public void RegisterBinaryOperator(TokenClass opToken, Precedence precedence, 
			bool rightAssociative = false)
		{
			Logger.Log(LogLevel.Debug, Logger.REGISTRY, 
				"Registering binary operator parselet for token " + opToken.ToString());
			InfixParselets.Add(opToken, new BinaryOperatorParselet(precedence, rightAssociative));
		}

		public void RegisterPostfixOperator(TokenClass opToken)
		{
			Logger.Log(LogLevel.Debug, Logger.REGISTRY, 
				"Registering postfix operator parselet for token " + opToken.ToString());
			InfixParselets.Add(opToken, new PostfixOperatorParselet(Precedence.POSTFIX));
		}
		#endregion

		// Pratt Parser (http://journal.stuffwithstuff.com/2011/03/19/pratt-parsers-expression-parsing-made-easy/)
		public NodeFactor Parse(Precedence precedence = (Precedence)0)
		{
			Logger.Log(LogLevel.Debug, Logger.PARSER, 
				"Beginning parse for precedence " + precedence.ToString());
			Token token = Consume();
			IPrefixParselet prefix = GetPrefix(token.Class);

			if (prefix == null)
			{
				Logger.Log(LogLevel.Error, Logger.PARSER,
					"Parse failed on token " + token.ToString());
				throw new MismatchedRuleException("Could not parse: " + token.ToString());
			}
			
			NodeFactor left = prefix.Parse(this, token);
			Logger.Log(LogLevel.Debug, Logger.PARSER, "Parse created " +
				left.Type.ToString() + "from initial token " + token.ToString());

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

		public Precedence GetPrecedence()
		{
			Token ahead = LookAhead();
			if (ahead == null)
			{
				return 0;
			}

			IInfixParselet parselet = GetInfix(ahead.Class);
			if (parselet != null)
			{
				return parselet.PrecedenceLevel;
			}

			return 0;
		}

		public Token Consume(TokenClass tokClass)
		{
			Token tok = LookAhead(0);
			if (tok.Class != tokClass)
			{
				Logger.Log(LogLevel.Error, Logger.PARSER, "Unexpected token found: " + 
					tok.Class.ToString());
				throw new MismatchedRuleException("Expected token " + 
					tokClass.ToString() + ". Found " + tok.Class.ToString());
			}

			return Consume();
		}

		public bool Match(TokenClass expected)
		{
			Token token = LookAhead();
			if (token.Class != expected)
			{
				return false;
			}

			Consume();
			return true;
		}

		public Token Consume()
		{
			LookAhead();

			Token rem = readTokens[0];
			readTokens.RemoveAt(0);
			return rem;
		}

		public Token LookAhead(int distance = 0)
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
