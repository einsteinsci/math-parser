﻿using System;
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

		public TokenStream Lexed
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

				List<TokenClass> validCurrent = ValidTokens(lexeme);
				List<TokenClass> validNext = ValidTokens(lexeme + c);
				List<TokenClass> validNextNext = nextC != null ? ValidTokens(lexeme + c + nextC.Value) : new List<TokenClass>();

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
					if (!lexeme.StartsWith("\""))
					{
						lexeme = lexeme.Trim();
					}
					continue;
				}

				if (validCurrent.Count == 0)
				{
					Logger.Log(LogLevel.Warning, Logger.LEXER, 
						"No last-choice Tokens. Waiting on " + lexeme);
					lexeme += c;
					if (!lexeme.StartsWith("\""))
					{
						lexeme = lexeme.Trim();
					}
					continue;
				}

				if (validCurrent.Count > 1)
				{
					Logger.Log(LogLevel.Warning, Logger.LEXER,
						"Multiple last-choice Tokens:  " +
						TokensToString(validCurrent));
				}

				FinalizeToken(validCurrent.FirstOrDefault(), lexeme);
				lexeme = c.ToString();
			}

			List<TokenClass> validCurrent_ = ValidTokens(lexeme);

			if (validCurrent_.Count == 0)
			{
				Logger.Log(LogLevel.Error, Logger.LEXER, 
					"No last-choice Tokens. Disposing " + lexeme);
			}

			if (validCurrent_.Count > 2) // excluding unrecognized
			{
				Logger.Log(LogLevel.Warning, Logger.LEXER,
					"Multiple last-choice Tokens:  " +
					TokensToString(validCurrent_));
			}

			TokenClass tok = validCurrent_.FirstOrDefault();
			FinalizeToken(tok, lexeme);
			#endregion

			#region resolve disambiguations
			for (int i = 0; i < Lexed.Count; i++)
			{
				Token l = Lexed[i];

				// minus
				if (l.Class == TokenClass.OperatorMinus)
				{
					if (i == 0) // first
					{
						Logger.Log(LogLevel.Debug, Logger.LEXER,
							"Converting minus (index " + i.ToString() + ") to negative.");
						l.Class = TokenClass.OperatorNegative;
						continue;
					}

					Token prev = Lexed[i - 1];
					if (prev.Class.Type == TokenType.Ignored)
					{
						bool found = false;
						for (int j = i - 1; j >= 0; j--)
						{
							if (Lexed[j].Class.Type != TokenType.Ignored)
							{
								found = true;
								prev = Lexed[j];
								break;
							}
						}
						if (!found)
						{
							// minus is first meaningful token
							l.Class = TokenClass.OperatorNegative;
							Logger.Log(LogLevel.Debug, Logger.LEXER,
								"Converting minus (index " + i.ToString() + ") to negative.");
							continue;
						}
					}

					if (prev.Class.Type == TokenType.Encloser)
					{
						TokenClassEncloser encl = prev.Class as TokenClassEncloser;
						if (encl.Side == EncloserSide.Opening)
						{
							l.Class = TokenClass.OperatorNegative;
							Logger.Log(LogLevel.Debug, Logger.LEXER,
								"Converting minus (index " + i.ToString() + ") to negative.");
							continue;
						}
					}
					else if (prev.Class.Type == TokenType.Delimiter)
					{
						l.Class = TokenClass.OperatorNegative;
						Logger.Log(LogLevel.Debug, Logger.LEXER,
							"Converting minus (index " + i.ToString() + ") to negative.");
						continue;
					}
					else if (prev.Class.Type == TokenType.Operator)
					{
						l.Class = TokenClass.OperatorNegative;
						Logger.Log(LogLevel.Debug, Logger.LEXER,
							"Converting minus (index " + i.ToString() + ") to negative.");
						continue;
					}
				}
			}
			#endregion

			string info = "";
			foreach (Token l in Lexed)
			{
				info += l.ToString() + "\n\t";
			}
			info = info.Trim();
			Logger.Log(LogLevel.Debug, Logger.LEXER,
				"Lexing complete:\n\t" + info);
		}

		public void FinalizeToken(TokenClass token, string lexeme)
		{
			if (token == null)
			{
				Logger.Log(LogLevel.Error, Logger.LEXER, 
					"Token is null. Filling with Unrecognized.");
				Lexed.Add(new Token(TokenClass.Unrecognized, lexeme));
				System.Diagnostics.Debugger.Break();
				return;
			}

			Logger.Log(LogLevel.Debug, Logger.LEXER,
				"Finalizing Token " + token.ToString() + " for lexeme: " + lexeme);
			Lexed.Add(new Token(token, lexeme));
		}
		
		public static string TokensToString(List<TokenClass> tokens)
		{
			string res = "{ ";
			foreach (TokenClass t in tokens)
			{
				res += t.ToString() + ",";
			}

			return res.TrimEnd(',') + " }";
		}

		public static List<TokenClass> ValidTokens(string lexeme)
		{
			if (lexeme == "")
			{
				return TokenRegistry.Tokens;
			}

			List<TokenClass> res = new List<TokenClass>();
			foreach (TokenClass token in TokenRegistry.Tokens)
			{
				if (token.Matches(lexeme) && token != TokenClass.Unrecognized)
				{
					res.Add(token);
				}
			}

			return res;
		}

		public static TokenStream Lex(string expression)
		{
			Instance.Lexed = new TokenStream();
			Instance.Expression = expression;

			Instance.Lex();

			return Instance.Lexed;
		}
    }
}
