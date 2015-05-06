using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[Token("number", 5)]
	public sealed class TokenNumber : Token
	{
		public override bool SingleChar
		{
			get { return false; }
		}

		public override bool Matches(string lexeme)
		{
			foreach (Token t in TokenRegistry.Tokens)
			{
				if (t.IsOperator && t.Matches(lexeme))
				{
					return false;
				}
			}

			if (!lexeme[0].IsNumeric())
			{
				return false;
			}

			int res;
			return int.TryParse(lexeme, out res);
		}

		public override string ToString()
		{
			return "[Number]";
		}
	}
}
