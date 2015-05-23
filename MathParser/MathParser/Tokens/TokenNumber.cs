using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathPlusLib.Extensions;

namespace MathParser.Tokens
{
	[MakeToken("number")]
	public sealed class TokenNumber : TokenLiteral
	{
		public override bool Matches(string lexeme)
		{
			// no european types here
			if (lexeme.StartsWith(",") || lexeme.EndsWith(","))
			{
				return false;
			}

			foreach (Token t in TokenRegistry.Tokens)
			{
				if (t.Type == TokenType.Operator && t.Matches(lexeme))
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

		public override NodeLiteral MakeNode(string lexeme)
		{
			long n = -1;
			if (long.TryParse(lexeme, out n))
			{
				return new NodeLiteral(new ResultNumberInteger(n));
			}
			else
			{
				return new NodeLiteral(new ResultNumberReal(double.Parse(lexeme)));
			}
		}

		public override string ToString()
		{
			return "[Number]";
		}
	}
}
