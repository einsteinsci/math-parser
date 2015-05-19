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

		//public const int PREC_ASSIGNMENT = 0;
		//public const int PREC_CONDITIONAL_TERNARY = 1;
		//public const int PREC_CONDITIONAL_OR = 2;
		//public const int PREC_CONDITIONAL_AND = 3;
		//public const int PREC_LOGICAL_OR = 4;
		//public const int PREC_LOGICAL_XOR = 5;
		//public const int PREC_LOGICAL_AND = 6;
		//public const int PREC_EQUALITY = 7;
		//public const int PREC_RELATIONAL = 8;
		public const int PREC_BITSHIFT = 9;
		public const int PREC_ADDITIVE = 10;
		public const int PREC_MULTIPLICATIVE = 11;
		public const int PREC_UNARY = 12;
		public const int PREC_EXPONENTIAL = 13;
		//public const int PREC_PRIMARY = 14;

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

		public override bool Matches(Token previous, string lexeme)
		{
			return lexeme == Operator;
		}

		public override string ToString()
		{
			return "[Operator" + Operator + "]";
		}
	}
}
