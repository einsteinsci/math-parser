using MathParser.ParseTree;
using MathParser.Lexing;
using MathParser.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathPlusLib.Extensions;

namespace MathParser.Lexing
{
	[TokenType("number")]
	public sealed class TokenTypeNumber : TokenTypeLiteral
	{
		public override bool Matches(string lexeme)
		{
			// no european types here
			if (lexeme.StartsWith(",") || lexeme.EndsWith(","))
			{
				return false;
			}

			foreach (TokenType t in TokenTypeRegistry.Tokens)
			{
				if (t is TokenTypeOperator && t.Matches(lexeme))
				{
					return false;
				}
			}

			if (!lexeme[0].IsNumeric() && lexeme[0] != '.')
			{
				return false;
			}

			double res;
			return double.TryParse(lexeme, out res);
		}

		public override string ToString()
		{
			return "[Number]";
		}
	}
}
