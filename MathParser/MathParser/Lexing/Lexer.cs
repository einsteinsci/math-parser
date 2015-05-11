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

		public List<Lexeme> Lexed
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

			#region for
			for (int index = 0; index < Expression.Length; index++)
			{
				char c = Expression[index];

				List<Token> validCurrent = ValidTokens(lexeme);
				List<Token> validNext = ValidTokens(lexeme + c);

				if (c.IsWhitespace())
				{
					FinalizeToken(validCurrent.FirstOrDefault(), lexeme);
					lexeme = "";
					continue;
				}

				if (lexeme == "")
				{
					lexeme += c;
					continue;
				}

				if (validCurrent.Count == 2 /* && validCurrent.First().SingleChar */) // excluding unrecognized
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

				if (validCurrent.Count == 0)
				{
					Logger.Log(LogLevel.Warning, "lexer", 
						"No last-choice Tokens. Waiting on " + lexeme);
					lexeme += c;
					continue;
				}

				if (validCurrent.Count > 2) // excluding unrecognized
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

			string info = "\n\t";
			foreach (Lexeme l in Lexed)
			{
				info += l.ToString() + "\n\t";
			}
			Logger.Log(LogLevel.Debug, "lexer", "");
			Logger.Log(LogLevel.Debug, "lexer",
				"Lexing complete: " + info);
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

		public static List<Lexeme> Lex(string expression)
		{
			Instance.Lexed = new List<Lexeme>();
			Instance.Expression = expression;

			Instance.Lex();

			return Instance.Lexed;
		}
    }
}
