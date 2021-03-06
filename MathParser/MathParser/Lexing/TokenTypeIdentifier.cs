﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MathParser.Lexing
{
	[TokenType("identifier")]
	public class TokenTypeIdentifier : TokenType
	{
		public override int LexerPriority
		{ get { return 6; } }

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

		public override string ToString()
		{
			return "[Identifier]";
		}
	}
}
