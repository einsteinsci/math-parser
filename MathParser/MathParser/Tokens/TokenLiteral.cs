using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	public abstract class TokenLiteral : Token
	{
		public override TokenType Type
		{ get { return TokenType.Literal; } }
	}
}
