using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[Token("number")]
	public sealed class TokenNumber : Token
	{
		public override bool Matches(string lexeme)
		{
			int res;
			return int.TryParse(lexeme, out res);
		}
	}
}
