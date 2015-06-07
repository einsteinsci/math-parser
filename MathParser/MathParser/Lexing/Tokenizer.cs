using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.Lexing;

namespace MathParser.Lexing
{
    public sealed class Tokenizer
    {
		public static readonly Tokenizer Instance = new Tokenizer();

		public string Expression
		{ get; set; }

		public TokenStream Lexed
		{ get; private set; }

		public void Lex()
		{
			if (!TokenTypeRegistry.HasRegistered)
			{
				TokenTypeRegistry.RegisterTokens();
			}

			if (Expression == null)
			{
				return;
			}

			Logger.Log(LogLevel.Info, Logger.TOKENIZER, "Beginning lexing...");

			string lexeme = "";

			#region lexing
			for (int index = 0; index < Expression.Length; index++)
			{
				char c = Expression[index];
				char? nextC = index < Expression.Length - 1 ? (char?)Expression[index + 1] : null;

				List<TokenType> validCurrent = ValidTokens(lexeme);
				List<TokenType> validNext = ValidTokens(lexeme + c);
				List<TokenType> validNextNext = nextC != null ? 
					ValidTokens(lexeme + c + nextC.Value) : new List<TokenType>();

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
					Logger.Log(LogLevel.Debug, Logger.TOKENIZER, 
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
					Logger.Log(LogLevel.Warning, Logger.TOKENIZER,
						"Multiple last-choice Tokens: " +
						TokensToString(validCurrent));
				}

				FinalizeToken(validCurrent.FirstOrDefault(), lexeme);
				lexeme = c.ToString();
			}

			List<TokenType> validCurrent_ = ValidTokens(lexeme);

			if (validCurrent_.Count == 0)
			{
				Logger.Log(LogLevel.Error, Logger.TOKENIZER, 
					"No last-choice Tokens. Disposing " + lexeme);
			}

			if (validCurrent_.Count > 2) // excluding unrecognized
			{
				Logger.Log(LogLevel.Warning, Logger.TOKENIZER,
					"Multiple last-choice Tokens:  " +
					TokensToString(validCurrent_));
			}

			TokenType tok = validCurrent_.FirstOrDefault();
			FinalizeToken(tok, lexeme);
			#endregion

			string info = "";
			foreach (Token l in Lexed)
			{
				info += l.ToString() + "\n    ";
			}
			info = info.Trim();
			Logger.Log(LogLevel.Info, Logger.TOKENIZER, "Lexing complete.");
			Logger.Log(LogLevel.Debug, Logger.TOKENIZER, "Tokens: \n    " + info);
		}

		public void FinalizeToken(TokenType token, string lexeme)
		{
			if (token == null)
			{
				Logger.Log(LogLevel.Error, Logger.TOKENIZER, 
					"Token is null. Filling with Unrecognized.");
				Lexed.Add(new Token(TokenType.Unrecognized, lexeme));
				System.Diagnostics.Debugger.Break();
				return;
			}

			Logger.Log(LogLevel.Debug, Logger.TOKENIZER,
				"Finalizing Token " + token.ToString() + " for lexeme: " + lexeme);
			Lexed.Add(new Token(token, lexeme));
		}
		
		public static string TokensToString(List<TokenType> tokens)
		{
			string res = "{ ";
			foreach (TokenType t in tokens)
			{
				res += t.ToString() + ",";
			}

			return res.TrimEnd(',') + " }";
		}

		public static List<TokenType> ValidTokens(string lexeme)
		{
			if (lexeme == "")
			{
				return TokenTypeRegistry.Tokens;
			}

			List<TokenType> res = new List<TokenType>();
			foreach (TokenType token in TokenTypeRegistry.Tokens)
			{
				if (token.Matches(lexeme) && token != TokenType.Unrecognized)
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
