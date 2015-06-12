using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathPlusLib;

namespace MathParser.Types
{
	/// <summary>
	/// Represents a real number value
	/// </summary>
	public sealed class ResultNumberReal : IResultValue
	{
		/// <summary>
		/// Type of value stored within the result
		/// </summary>
		public MathType Type
		{ get { return MathType.Real; } }

		/// <summary>
		/// Internal object held, storing the result's data
		/// </summary>
		public object CoreValue
		{ get { return Value; } }

		/// <summary>
		/// Internal floating-point value stored
		/// </summary>
		public decimal Value
		{ get; set; }

		/// <summary>
		/// Instantiates a new ResultNumberReal.
		/// </summary>
		public ResultNumberReal(decimal d)
		{
			Value = d;
		}

		/// <summary>
		/// Instantiates a new ResultNumberReal.
		/// </summary>
		public ResultNumberReal(double d)
		{
			Value = (decimal)d;
		}

		/// <summary>
		/// Instantiates a new ResultNumberReal.
		/// </summary>
		public ResultNumberReal(float f)
		{
			Value = (decimal)f;
		}

		/// <summary>
		/// Converts the result to a decimal.
		/// </summary>
		public decimal ToDecimal()
		{
			return Value;
		}

		/// <summary>
		/// Converts the result to an int
		/// </summary>
		public long ToInteger()
		{
			return (long)Value;
		}

		/// <summary>
		/// Converts the result to a bool
		/// </summary>
		public bool ToBoolean()
		{
			return ToInteger() == 0 ? false : true;
		}

		/// <summary>
		/// Converts the result to a list
		/// </summary>
		public List<decimal> ToList()
		{
			return new List<decimal>() { ToDecimal() };
		}

		/// <summary>
		/// Gets the display string of the object
		/// </summary>
		public string ToDisplayString()
		{
			return Value.ToString();
		}

		/// <summary>
		/// Converts the result to a string
		/// </summary>
		public override string ToString()
		{
			return Value.ToString();
		}

		/// <summary>
		/// Conversion operator overload to a ResultNumberInteger. Cast required.
		/// </summary>
		public static explicit operator ResultNumberInteger(ResultNumberReal real)
		{
			return new ResultNumberInteger(real.ToInteger());
		}
	}
}
