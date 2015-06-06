using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Parsing;

namespace MathParser.Lexing
{
	public abstract class TokenTypeOperator : TokenType
	{
		public const int PRIORITY = 4;

		public abstract string Operator
		{ get; }

		public override int LexerPriority
		{ get { return PRIORITY; } }

		public virtual bool IsRightAssociative
		{ get { return false; } }

		public override bool Matches(string lexeme)
		{
			return lexeme == Operator;
		}

		public override string ToString()
		{
			return "[Operator" + Operator + "]";
		}
	}
}
