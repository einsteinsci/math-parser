using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.ParseTree;
using MathParser.Lexing;

namespace MathParser.Parsing
{
	public sealed class PrattParser
	{
		public delegate void PrefixLoadEvent(object sender, PrefixLoadingEventArgs e);
		public delegate void InfixLoadEvent(object sender, InfixLoadingEventArgs e);

		public static Dictionary<TokenType, IPrefixParselet> PrefixParselets
		{ get; private set; }

		public static Dictionary<TokenType, IInfixParselet> InfixParselets
		{ get; private set; }

		public TokenStream Stream
		{ get; private set; }

		public static bool HasRegistered
		{ get; private set; }

		List<Token> readTokens = new List<Token>();

		public static event PrefixLoadEvent PrefixLoading;
		public static event InfixLoadEvent InfixLoading;

		public PrattParser(TokenStream stream)
		{
			Stream = stream;
			Init();
		}

		public static NodeFactor Parse(TokenStream stream)
		{
			PrattParser inst = new PrattParser(stream);
			NodeFactor res = inst.Parse();

			Logger.Log(LogLevel.Info, Logger.PARSER, "Parsing Complete.");
			Logger.Log(LogLevel.Debug, Logger.PARSER, "Completed tree:\n" + res.GetTreeString("    "));
            
			return res;
		}

		public static void Init(bool force = false)
		{
			if (HasRegistered && !force)
			{
				return;
			}

			Logger.Log(LogLevel.Info, Logger.REGISTRY, "Starting parselet registry.");
			PrefixParselets = new Dictionary<TokenType, IPrefixParselet>();

			Logger.Log(LogLevel.Debug, Logger.REGISTRY, "Registering prefix parselets.");
			PrefixParselets.Add(TokenType.Identifier, new NameParselet());
			PrefixParselets.Add(TokenType.Number, new NumberParselet());
			PrefixParselets.Add(TokenType.String, new StringParselet());
			PrefixParselets.Add(TokenType.Boolean, new BooleanParselet());

			PrefixParselets.Add(TokenType.ParenthesisIn, new ParenthesisParselet());

			PrefixParselets.Add(TokenType.BraceIn, new ListLiteralParselet());

			foreach (TokenType tc in UnaryPrefixRegistry.GetTokens())
			{
				RegisterPrefixOperator(tc);
			}

			if (PrefixLoading != null)
			{
				PrefixLoading(null, new PrefixLoadingEventArgs(PrefixParselets));
			}

			InfixParselets = new Dictionary<TokenType, IInfixParselet>();

			Logger.Log(LogLevel.Debug, Logger.REGISTRY, "Registering infix and postfix parselets.");
			InfixParselets.Add(TokenType.ParenthesisIn, new FunctionCallParselet());
			InfixParselets.Add(TokenType.BracketIn, new ListOrdinalParselet());
			InfixParselets.Add(TokenType.OperatorQuestion, new ConditionalParselet());

			foreach (TokenType tc in BinaryInfixRegistry.GetTokens())
			{
				BinaryInfixRegistry.RegItem reg = BinaryInfixRegistry.Get(tc);
				RegisterBinaryOperator(tc, reg.PrecedenceLevel, reg.IsRightAssociative);
			}

			foreach (TokenType tc in UnaryPostfixRegistry.GetTokens())
			{
				RegisterPostfixOperator(tc);
			}

			if (InfixLoading != null)
			{
				InfixLoading(null, new InfixLoadingEventArgs(InfixParselets));
			}

			HasRegistered = false;
		}

		#region register
		public static void RegisterPrefix(TokenType token, IPrefixParselet parselet)
		{
			Logger.Log(LogLevel.Debug, Logger.REGISTRY,
				"Registering prefix parselet for token " + token.ToString());
			PrefixParselets.Add(token, parselet);
		}

		public static void RegisterPrefixOperator(TokenType opToken)
		{
			Logger.Log(LogLevel.Debug, Logger.REGISTRY, 
				"Registering prefix operator parselet for token " + opToken.ToString());
			PrefixParselets.Add(opToken, new PrefixOperatorParselet(Precedence.PREFIX));
		}

		public static void RegisterInfix(TokenType token, IInfixParselet parselet)
		{
			Logger.Log(LogLevel.Debug, Logger.REGISTRY,
				"Registering infix/postfix operator parselet for token " + token.ToString());
			InfixParselets.Add(token, parselet);
		}

		public static void RegisterBinaryOperator(TokenType opToken, Precedence precedence, 
			bool rightAssociative = false)
		{
			Logger.Log(LogLevel.Debug, Logger.REGISTRY, 
				"Registering binary operator parselet for token " + opToken.ToString());
			InfixParselets.Add(opToken, new BinaryOperatorParselet(precedence, rightAssociative));
		}

		public static void RegisterPostfixOperator(TokenType opToken)
		{
			Logger.Log(LogLevel.Debug, Logger.REGISTRY, 
				"Registering postfix operator parselet for token " + opToken.ToString());
			InfixParselets.Add(opToken, new PostfixOperatorParselet(Precedence.POSTFIX));
		}
		#endregion

		// Pratt Parser (http://journal.stuffwithstuff.com/2011/03/19/pratt-parsers-expression-parsing-made-easy/)
		public NodeFactor Parse(Precedence precedence = 0)
		{
			Logger.Log(LogLevel.Debug, Logger.PARSER, 
				"Beginning parse for precedence " + precedence.ToString());
			Token token = Consume();
			IPrefixParselet prefix = GetPrefix(token.Type);

			if (prefix == null)
			{
				Logger.Log(LogLevel.Error, Logger.PARSER,
					"Parse failed on token " + token.ToString());
				throw new MismatchedRuleException("Could not parse: " + token.ToString());
			}
			
			NodeFactor left = prefix.Parse(this, token);
			Logger.Log(LogLevel.Debug, Logger.PARSER, "Parse created " +
				left.GetType().Name + " from initial token " + token.ToString());

			while (precedence < GetPrecedence())
			{
				token = Consume();

				IInfixParselet infix = GetInfix(token.Type);
				left = infix.Parse(this, left, token);
			}

			return left;
		}

		public static IPrefixParselet GetPrefix(TokenType tokenClass)
		{
			if (PrefixParselets.ContainsKey(tokenClass))
			{
				return PrefixParselets[tokenClass];
			}

			return null;
		}

		public static IInfixParselet GetInfix(TokenType tokenClass)
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

			IInfixParselet parselet = GetInfix(ahead.Type);
			if (parselet != null)
			{
				return parselet.PrecedenceLevel;
			}

			return 0;
		}

		public Token Consume(TokenType tokClass)
		{
			Token tok = LookAhead(0);
			if (tok.Type != tokClass)
			{
				Logger.Log(LogLevel.Error, Logger.PARSER, "Unexpected token found: " + 
					tok.Type.ToString());
				throw new MismatchedRuleException("Expected token " + 
					tokClass.ToString() + ". Found " + tok.Type.ToString());
			}

			return Consume();
		}

		public bool Match(TokenType expected)
		{
			Token token = LookAhead();
			if (token.Type != expected)
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
