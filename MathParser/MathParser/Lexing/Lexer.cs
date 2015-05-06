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
			if (Token.Registry == null)
			{
				Token.RegisterTokens();
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

				if (c == '+')
				{
					int stuppid = 0;
				}

				if (c.IsWhitespace())
				{
					continue;
				}

				if (lexeme == "")
				{
					lexeme += c;
					continue;
				}

				List<Token> validNext = ValidTokens(lexeme + c);
				if (validNext.Count > 0)
				{
					lexeme += c;
					continue;
				}

				List<Token> validCurrent = ValidTokens(lexeme);

				if (validCurrent.Count == 0)
				{
					Logger.Log(LogLevel.Error, "lexer", 
						"No last-choice Tokens. Disposing " + lexeme);
					lexeme = "";
					continue;
				}

				if (validCurrent.Count > 1)
				{
					Logger.Log(LogLevel.Warning, "lexer",
						"Multiple last-choice Tokens:  " +
						TokensToString(validCurrent));
				}

				Token t = validCurrent.FirstOrDefault();
				Logger.Log(LogLevel.Debug, "lexer",
					"Finalizing Token " + t.ToString() + " for lexeme: " + lexeme);
				Lexed.Add(new Lexeme(t, lexeme));
				lexeme = c.ToString();
			}

			List<Token> validCurrent_ = ValidTokens(lexeme);

			if (validCurrent_.Count == 0)
			{
				Logger.Log(LogLevel.Error, "lexer", 
					"No last-choice Tokens. Disposing " + lexeme);
			}

			if (validCurrent_.Count > 1)
			{
				Logger.Log(LogLevel.Warning, "lexer",
					"Multiple last-choice Tokens:  " +
					TokensToString(validCurrent_));
			}

			Token tok = validCurrent_.FirstOrDefault();
			Logger.Log(LogLevel.Debug, "lexer",
				"Finalizing Token " + tok.ToString() + " for lexeme: " + lexeme);
			Lexed.Add(new Lexeme(tok, lexeme));
			#endregion
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
				return Token.Registry.Values.ToList();
			}

			List<Token> res = new List<Token>();
			foreach (Token token in Token.Registry.Values)
			{
				if (token.Matches(lexeme))
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
