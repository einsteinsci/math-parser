using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[Token("comment")]
	public class TokenComment : Token
	{
		public override bool SingleChar
		{
			get { return false; }
		}

		public override bool Matches(string lexeme)
		{
			return lexeme.StartsWith("/*") && lexeme.EndsWith("*/");
		}

		public override string ToString()
		{
			return "[T] Comment";
		}
	}
}
