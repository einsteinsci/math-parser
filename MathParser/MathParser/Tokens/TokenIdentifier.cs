using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.Lexing;

namespace MathParser.Tokens
{
	[Token("identifier", 6)]
	public class TokenIdentifier : Token
	{
		public override bool SingleChar
		{
			get { return false; }
		}

		public override bool Matches(string lexeme)
		{
			if (lexeme == "")
			{
				return true;
			}

			if (!lexeme[0].IsAlphabetic() && lexeme[0] != '_')
			{
				return false;
			}

			foreach (char c in lexeme)
			{
				if (!c.IsAlphaNumeric() && c != '_')
				{
					return false;
				}
			}

			return true;
		}

		public override TokenType Type
		{ get { return TokenType.Name; } }

		public override string ToString()
		{
			return "[Identifier]";
		}
	}
}
