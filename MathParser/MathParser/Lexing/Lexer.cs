using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.Tokens;

namespace MathParser.Lexing
{
    public sealed class Lexer
    {
		public static readonly Lexer Instance = new Lexer();

		public string Expression
		{ get; set; }

		public LexStream Lexed
		{ get; private set; }

		public void Lex()
		{
			if (!TokenRegistry.HasRegistered)
			{
				TokenRegistry.RegisterTokens();
			}

			if (Expression == null)
			{
				return;
			}

			string lexeme = "";

			#region lexing
			for (int index = 0; index < Expression.Length; index++)
			{
				char c = Expression[index];
				char? nextC = index < Expression.Length - 1 ? (char?)Expression[index + 1] : null;

				List<Token> validCurrent = ValidTokens(lexeme);
				List<Token> validNext = ValidTokens(lexeme + c);
				List<Token> validNextNext = nextC != null ? ValidTokens(lexeme + c + nextC.Value) : new List<Token>();

				if (lexeme == "")
				{
					lexeme += c;
					continue;
				}

				if (c.IsWhitespace() && !lexeme.StartsWith("\""))
				{
					FinalizeToken(validCurrent.FirstOrDefault(), lexeme);
					lexeme = "";
					continue;
				}

				if (validCurrent.Count == 1 && validNext.Count == 0)
				{
					FinalizeToken(validCurrent.FirstOrDefault(), lexeme);
					lexeme = c.ToString();
					continue;
				}

				if (validNext.Count > 0)
				{
					lexeme += c;
					continue;
				}

				if (validCurrent.Count == 0 && !lexeme.StartsWith("\""))
				{
					Logger.Log(LogLevel.Warning, "lexer", 
						"No last-choice Tokens. Waiting on " + lexeme);
					lexeme += c;
					continue;
				}

				if (validCurrent.Count > 1)
				{
					Logger.Log(LogLevel.Warning, "lexer",
						"Multiple last-choice Tokens:  " +
						TokensToString(validCurrent));
				}

				FinalizeToken(validCurrent.FirstOrDefault(), lexeme);
				lexeme = c.ToString();
			}

			List<Token> validCurrent_ = ValidTokens(lexeme);

			if (validCurrent_.Count == 0)
			{
				Logger.Log(LogLevel.Error, "lexer", 
					"No last-choice Tokens. Disposing " + lexeme);
			}

			if (validCurrent_.Count > 2) // excluding unrecognized
			{
				Logger.Log(LogLevel.Warning, "lexer",
					"Multiple last-choice Tokens:  " +
					TokensToString(validCurrent_));
			}

			Token tok = validCurrent_.FirstOrDefault();
			FinalizeToken(tok, lexeme);
			#endregion

			#region resolve disambiguations
			for (int i = 0; i < Lexed.Count; i++)
			{
				Lexeme l = Lexed[i];

				// minus
				if (l.Token == Token.OperatorMinus)
				{
					if (i == 0) // first
					{
						Logger.Log(LogLevel.Debug, "lexer",
							"Converting minus (index " + i.ToString() + ") to negative.");
						l.Token = Token.OperatorNegative;
						continue;
					}

					Lexeme prev = Lexed[i - 1];
					if (prev.Token.Type == TokenType.Ignored)
					{
						bool found = false;
						for (int j = i - 1; j >= 0; j--)
						{
							if (Lexed[j].Token.Type != TokenType.Ignored)
							{
								found = true;
								prev = Lexed[j];
								break;
							}
						}
						if (!found)
						{
							// minus is first meaningful token
							l.Token = Token.OperatorNegative;
							Logger.Log(LogLevel.Debug, "lexer",
								"Converting minus (index " + i.ToString() + ") to negative.");
							continue;
						}
					}

					if (prev.Token.Type == TokenType.Encloser)
					{
						TokenEncloser encl = prev.Token as TokenEncloser;
						if (encl.Side == EncloserSide.Opening)
						{
							l.Token = Token.OperatorNegative;
							Logger.Log(LogLevel.Debug, "lexer",
								"Converting minus (index " + i.ToString() + ") to negative.");
							continue;
						}
					}
					else if (prev.Token.Type == TokenType.Delimiter)
					{
						l.Token = Token.OperatorNegative;
						Logger.Log(LogLevel.Debug, "lexer",
							"Converting minus (index " + i.ToString() + ") to negative.");
						continue;
					}
					else if (prev.Token.Type == TokenType.Operator)
					{
						l.Token = Token.OperatorNegative;
						Logger.Log(LogLevel.Debug, "lexer",
							"Converting minus (index " + i.ToString() + ") to negative.");
						continue;
					}
				}
			}
			#endregion

			string info = "";
			foreach (Lexeme l in Lexed)
			{
				info += l.ToString() + "\n\t";
			}
			info = info.Trim();
			Logger.Log(LogLevel.Debug, "lexer",
				"Lexing complete:\n\t" + info);
		}

		public void FinalizeToken(Token token, string lexeme)
		{
			if (token == null)
			{
				Logger.Log(LogLevel.Error, "lexer", 
					"Token is null. Filling with Unrecognized.");
				Lexed.Add(new Lexeme(Token.Unrecognized, lexeme));
				return;
			}

			Logger.Log(LogLevel.Debug, "lexer",
				"Finalizing Token " + token.ToString() + " for lexeme: " + lexeme);
			Lexed.Add(new Lexeme(token, lexeme));
		}
		
		public static string TokensToString(List<Token> tokens)
		{
			string res = "{ ";
			foreach (Token t in tokens)
			{
				res += t.ToString() + ",";
			}

			return res.TrimEnd(',') + " }";
		}

		public static List<Token> ValidTokens(string lexeme)
		{
			if (lexeme == "")
			{
				return TokenRegistry.Tokens;
			}

			List<Token> res = new List<Token>();
			foreach (Token token in TokenRegistry.Tokens)
			{
				if (token.Matches(lexeme) && token != Token.Unrecognized)
				{
					res.Add(token);
				}
			}

			return res;
		}

		public static LexStream Lex(string expression)
		{
			Instance.Lexed = new LexStream();
			Instance.Expression = expression;

			Instance.Lex();

			return Instance.Lexed;
		}
    }
}
