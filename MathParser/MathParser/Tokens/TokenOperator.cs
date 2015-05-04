using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	public abstract class TokenOperator : Token
	{
		public abstract string Operator
		{ get; }

		public override bool Matches(string lexeme)
		{
			return lexeme == Operator;
		}

		public override string ToString()
		{
			return "[T] Operator " + Operator;
		}
	}
}
