using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.ParseTree;
using MathParser.Lexing;

namespace MathParser.Parsing
{
	/// <summary>
	/// Used for loading prefix parselets
	/// </summary>
	/// <param name="sender">Object triggering the load. Mostly useless.</param>
	/// <param name="e">EventArgs containing all the required data for load</param>
	public delegate void PrefixLoadEvent(object sender, PrefixLoadingEventArgs e);

	/// <summary>
	/// Used for loading infix, postfix, and mixfix parselets
	/// </summary>
	/// <param name="sender">Object triggering the load. Mostly useless.</param>
	/// <param name="e">EventArgs containing all the required data for load</param>
	public delegate void InfixLoadEvent(object sender, InfixLoadingEventArgs e);

	/// <summary>
	/// Class that does the parsing of a token stream into a parse tree.
	/// This is where the important stuff happens.
	/// </summary>
	public sealed class Parser
	{
		/// <summary>
		/// Registry of loaded prefix parselets
		/// </summary>
		public static Dictionary<TokenType, IPrefixParselet> PrefixParselets
		{ get; private set; }
		
		/// <summary>
		/// Registry of loaded infix/postfix/mixfix parselets
		/// </summary>
		public static Dictionary<TokenType, IInfixParselet> InfixParselets
		{ get; private set; }

		/// <summary>
		/// Input token stream
		/// </summary>
		public TokenStream Stream
		{ get; private set; }

		private static bool hasRegistered;

		List<Token> readTokens = new List<Token>();

		/// <summary>
		/// Event for loading prefix parselets. Subscribe your
		/// prefix parselet loading code to this event.
		/// </summary>
		public static event PrefixLoadEvent PrefixLoading;

		/// <summary>
		/// Event for loading infix/postfix/mixfix parselets.
		/// Subscribe your infix/postfix/mixfix parselet loading
		/// code to this event.
		/// </summary>
		public static event InfixLoadEvent InfixLoading;

		/// <summary>
		/// Instantiates a new PrattParser
		/// </summary>
		public Parser(TokenStream stream)
		{
			Stream = stream;
			Init();
		}

		/// <summary>
		/// Parses a token stream statically with a new instance.
		/// </summary>
		/// <param name="stream">Stream to parse</param>
		/// <returns>A Node containing the entire parse tree of the expression</returns>
		public static NodeBase Parse(TokenStream stream)
		{
			Parser inst = new Parser(stream);
			NodeBase res = inst.Parse();

			Logger.Log(LogLevel.Info, Logger.PARSER, "Parsing Complete.");
			Logger.Log(LogLevel.Debug, Logger.PARSER, "Completed tree:\n" + res.GetTreeString("    "));
            
			return res;
		}

		/// <summary>
		/// Initialization logic, called on the first instantiation of a Parser object.
		/// </summary>
		/// <param name="force">Force re-initialization</param>
		public static void Init(bool force = false)
		{
			if (hasRegistered && !force)
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

			hasRegistered = false;
		}

		#region register
		/// <summary>
		/// Registers a token type to a prefix parselet
		/// </summary>
		/// <param name="token">Token type to register</param>
		/// <param name="parselet">Parselet to register to</param>
		public static void RegisterPrefix(TokenType token, IPrefixParselet parselet)
		{
			Logger.Log(LogLevel.Debug, Logger.REGISTRY,
				"Registering prefix parselet for token " + token.ToString());
			PrefixParselets.Add(token, parselet);
		}

		/// <summary>
		/// Registers a token type to a new PrefixOperatorParselet
		/// </summary>
		/// <param name="opToken">Token type to register</param>
		public static void RegisterPrefixOperator(TokenType opToken)
		{
			Logger.Log(LogLevel.Debug, Logger.REGISTRY, 
				"Registering prefix operator parselet for token " + opToken.ToString());
			PrefixParselets.Add(opToken, new PrefixOperatorParselet(Precedence.PREFIX));
		}

		/// <summary>
		/// Registers a token type to an infix parselet
		/// </summary>
		/// <param name="token">Token type to register</param>
		/// <param name="parselet">Parselet to register to</param>
		public static void RegisterInfix(TokenType token, IInfixParselet parselet)
		{
			Logger.Log(LogLevel.Debug, Logger.REGISTRY,
				"Registering infix/postfix operator parselet for token " + token.ToString());
			InfixParselets.Add(token, parselet);
		}

		/// <summary>
		/// Registers a token type to a new BinaryOperatorParselet
		/// </summary>
		/// <param name="opToken">Token type to register</param>
		/// <param name="precedence">Precedence of operator</param>
		/// <param name="rightAssociative">If the operator is right-associative or not</param>
		public static void RegisterBinaryOperator(TokenType opToken, Precedence precedence, 
			bool rightAssociative = false)
		{
			Logger.Log(LogLevel.Debug, Logger.REGISTRY, 
				"Registering binary operator parselet for token " + opToken.ToString());
			InfixParselets.Add(opToken, new BinaryOperatorParselet(precedence, rightAssociative));
		}

		/// <summary>
		/// Registers a token type to a new PostfixOperatorParselet
		/// </summary>
		/// <param name="opToken">Token type to register</param>
		public static void RegisterPostfixOperator(TokenType opToken)
		{
			Logger.Log(LogLevel.Debug, Logger.REGISTRY, 
				"Registering postfix operator parselet for token " + opToken.ToString());
			InfixParselets.Add(opToken, new PostfixOperatorParselet(Precedence.POSTFIX));
		}
		#endregion

		// Pratt Parser (http://journal.stuffwithstuff.com/2011/03/19/pratt-parsers-expression-parsing-made-easy/)
		/// <summary>
		/// Parses a token stream stored in Stream
		/// </summary>
		/// <param name="precedence">
		///	  Precedence level to start at. Used only as 
		///	  inner part of the algorithm.
		/// </param>
		/// <returns>Resulting node in tree</returns>
		public NodeBase Parse(Precedence precedence = 0)
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
			
			NodeBase left = prefix.Parse(this, token);
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

		/// <summary>
		/// Gets the prefix parselet registered to the token type
		/// </summary>
		/// <param name="tokenClass">Token type to check</param>
		/// <returns>Parslet the token type is registered to</returns>
		public static IPrefixParselet GetPrefix(TokenType tokenClass)
		{
			if (PrefixParselets.ContainsKey(tokenClass))
			{
				return PrefixParselets[tokenClass];
			}

			return null;
		}

		/// <summary>
		/// Gets the infix parselet registered to the token type
		/// </summary>
		/// <param name="tokenClass">Token type to check</param>
		/// <returns>Parselet the token type is registered to</returns>
		public static IInfixParselet GetInfix(TokenType tokenClass)
		{
			if (InfixParselets.ContainsKey(tokenClass))
			{
				return InfixParselets[tokenClass];
			}

			return null;
		}

		/// <summary>
		/// Gets the current precedence in the parser's current state
		/// </summary>
		/// <returns>The precendence level being parsed</returns>
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

		/// <summary>
		/// Consumes a token as part of parsing
		/// </summary>
		/// <param name="tokType">Token type to expect</param>
		/// <returns>The token consumed</returns>
		public Token Consume(TokenType tokType)
		{
			Token tok = LookAhead(0);
			if (tok.Type != tokType)
			{
				Logger.Log(LogLevel.Error, Logger.PARSER, "Unexpected token found: " + 
					tok.Type.ToString());
				throw new MismatchedRuleException("Expected token " + 
					tokType.ToString() + ". Found " + tok.Type.ToString());
			}

			return Consume();
		}

		/// <summary>
		/// Gets whether the token stream's current token matches the
		/// token type.
		/// </summary>
		/// <param name="expected">Token type to expect</param>
		/// <returns>True if the token matches, false if not</returns>
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

		/// <summary>
		/// Consumes the next token unconditionally
		/// </summary>
		/// <returns>The token consumed</returns>
		public Token Consume()
		{
			LookAhead();

			Token rem = readTokens[0];
			readTokens.RemoveAt(0);
			return rem;
		}

		/// <summary>
		/// Peeks a certain number of tokens ahead in the token stream
		/// </summary>
		/// <param name="distance">Number of tokens to look ahead</param>
		/// <returns>Token peeked at</returns>
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
