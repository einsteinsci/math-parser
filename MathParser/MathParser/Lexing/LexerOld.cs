using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.Tokens;

namespace MathParser.Lexing
{
    public sealed class LexerOld
    {
		public static readonly LexerOld Instance = new LexerOld();

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
			Token previous = null;

			#region for
			for (int index = 0; index < Expression.Length; index++)
			{
				char c = Expression[index];

				List<Token> validCurrent = ValidTokens(previous, lexeme);
				List<Token> validNext = ValidTokens(previous, lexeme + c);

				if (validCurrent.Count == 1)
				{
					previous = validCurrent[0];
					validCurrent = ValidTokens(previous, lexeme);
					validNext = ValidTokens(previous, lexeme + c);
				}

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

				if (validCurrent.Count == 1)
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
				previous = Lexed.LastUsefulToken();
			}

			List<Token> validCurrent_ = ValidTokens(Lexed.LastUsefulToken(), lexeme);

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

		public static List<Token> ValidTokens(Token previous, string lexeme)
		{
			if (lexeme == "")
			{
				return TokenRegistry.Tokens;
			}

			List<Token> res = new List<Token>();
			foreach (Token token in TokenRegistry.Tokens)
			{
				if (token.Matches(previous, lexeme) && token != Token.Unrecognized)
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
