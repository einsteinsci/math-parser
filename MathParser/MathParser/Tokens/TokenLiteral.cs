using MathParser.ParseTree;
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

		public override int LexerPriority
		{ get { return 5; } }

		public abstract NodeLiteral MakeNode(string lexeme);
	}
}
