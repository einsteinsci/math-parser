using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Pratt
{
	/// <summary>
	/// Used much like an <see cref="int"/>. Explicit conversions 
	/// from <see cref="int"/> is acceptable: 
	/// <code>Precedence prec = (Precedence)5</code>
	/// </summary>
	public enum Precedence : int
	{
		ASSIGNMENT = 0,
		//CONDITIONAL_TERNARY = 1,
		CONDITIONAL_OR = 2,
		CONDITIONAL_AND = 3,
		//LOGICAL_OR = 4,
		//LOGICAL_XOR = 5,
		//LOGICAL_AND = 6,
		EQUALITY = 7,
		RELATIONAL = 8,
		BITSHIFT = 9,
		ADDITIVE = 10,
		MULTIPLICATIVE = 11,
		PREFIX = 12,
		POSTFIX = 13,
		EXPONENTIAL = 14,
		PRIMARY = 15, // also method calls
	}
}
