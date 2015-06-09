using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Parsing
{
	/// <summary>
	/// Used much like an <see cref="int"/>. Explicit conversions 
	/// from <see cref="int"/> is acceptable: 
	/// <code>Precedence prec = (Precedence)5</code>
	/// </summary>
	public enum Precedence : int
	{
		/// <summary>
		/// Assignment operators. Unused.
		/// </summary>
		ASSIGNMENT = 0,
		/// <summary>
		/// Ternary ?: operator from C
		/// </summary>
		CONDITIONAL_TERNARY = 1,
		/// <summary>
		/// Conditional or || from C
		/// </summary>
		CONDITIONAL_OR = 2,
		/// <summary>
		/// Conditional and &amp;&amp; from C
		/// </summary>
		CONDITIONAL_AND = 3,
		/// <summary>
		/// Logical or from C. Unused.
		/// </summary>
		LOGICAL_OR = 4,
		/// <summary>
		/// Logical xor from C. Unused.
		/// </summary>
		LOGICAL_XOR = 5,
		/// <summary>
		/// Logical and from C. Unused.
		/// </summary>
		LOGICAL_AND = 6,
		/// <summary>
		/// Equality comparison == or ~=. Returns a boolean.
		/// </summary>
		EQUALITY = 7,
		/// <summary>
		/// Relational comparison &lt; &lt;= &gt; &gt;=. Returns a boolean.
		/// </summary>
		RELATIONAL = 8,
		/// <summary>
		/// Bitshift operators from C. Unused.
		/// </summary>
		BITSHIFT = 9,
		/// <summary>
		/// Additive operators + -
		/// </summary>
		ADDITIVE = 10,
		/// <summary>
		/// Multiplicative operators * / %
		/// </summary>
		MULTIPLICATIVE = 11,
		/// <summary>
		/// Prefix operators ~ -
		/// </summary>
		PREFIX = 12,
		/// <summary>
		/// Postfix operators !
		/// </summary>
		POSTFIX = 13,
		/// <summary>
		/// Exponential operator ^
		/// </summary>
		EXPONENTIAL = 14,
		/// <summary>
		/// Primary operators such as groups (...), method calls,
		/// and ordinal access: [index]
		/// </summary>
		PRIMARY = 15,
	}
}
