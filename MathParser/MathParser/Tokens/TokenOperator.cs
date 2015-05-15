using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	public abstract class TokenOperator : Token
	{
		public const int PRIORITY = 4;

		public virtual int ArgumentCount
		{ get { return 2; } }

		public abstract string Operator
		{ get; }

		public override TokenType Type
		{ get { return TokenType.Operator; } }

		public virtual bool IsRightAssociative
		{ get { return false; } }

		public abstract int Precedence
		{ get; }

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
