using MathPlusLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;

namespace MathParser.Types
{
	/// <summary>
	/// An interface describing a result value that a parse tree can evaluate to.
	/// Override Object.ToString() to specify conversion to a string.
	/// </summary>
	public interface IResultValue : ITextDisplayable
	{
		/// <summary>
		/// Type of value stored within the result
		/// </summary>
		MathType Type
		{ get; }

		/// <summary>
		/// Internal object held, storing the result's data
		/// </summary>
		object CoreValue
		{ get; }

		/// <summary>
		/// Converts the result to a decimal.
		/// </summary>
		decimal ToDecimal();

		/// <summary>
		/// Converts the result to an int
		/// </summary>
		long ToInteger();

		/// <summary>
		/// Converts the result to a bool
		/// </summary>
		bool ToBoolean();

		/// <summary>
		/// Converts the result to a list
		/// </summary>
		List<decimal> ToList();
	}
}
