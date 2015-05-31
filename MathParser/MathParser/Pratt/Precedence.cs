using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Pratt
{
	public static class Precedence
	{
		public const int ASSIGNMENT = 0;
		//public const int CONDITIONAL_TERNARY = 1;
		public const int CONDITIONAL_OR = 2;
		public const int CONDITIONAL_AND = 3;
		//public const int LOGICAL_OR = 4;
		//public const int LOGICAL_XOR = 5;
		//public const int LOGICAL_AND = 6;
		public const int EQUALITY = 7;
		public const int RELATIONAL = 8;
		public const int BITSHIFT = 9;
		public const int ADDITIVE = 10;
		public const int MULTIPLICATIVE = 11;
		public const int PREFIX = 12;
		public const int POSTFIX = 13;
		public const int EXPONENTIAL = 14;
		public const int PRIMARY = 15; // also method calls
	}
}
