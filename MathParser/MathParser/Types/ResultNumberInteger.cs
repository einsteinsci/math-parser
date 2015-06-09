using MathPlusLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Types
{
	/// <summary>
	/// Represents an integral value
	/// </summary>
	public sealed class ResultNumberInteger : IResultValue
	{
		/// <summary>
		/// Type of value stored within the result
		/// </summary>
		public MathType Type
		{ get { return MathType.Integer; } }

		/// <summary>
		/// Internal object held, storing the result's data
		/// </summary>
		public object CoreValue
		{ get { return Value; } }

		/// <summary>
		/// Internal value stored.
		/// </summary>
		public long Value
		{ get; set; }

		/// <summary>
		/// Instantiates a new ResultNumberInteger
		/// </summary>
		public ResultNumberInteger(long value)
		{
			Value = value;
		}
		/// <summary>
		/// Instantiates a new ResultNumberInteger
		/// </summary>
		public ResultNumberInteger(int value)
		{
			Value = value;
		}

		/// <summary>
		/// Converts the result to a double.
		/// </summary>
		public double ToDouble()
		{
			return (double)Value;
		}

		/// <summary>
		/// Converts the result to an int
		/// </summary>
		public long ToInteger()
		{
			return Value;
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
		public List<double> ToList()
		{
			return new List<double>() { ToDouble() };
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
		/// Conversion operator overload to a ResultNumberReal
		/// </summary>
		public static implicit operator ResultNumberReal(ResultNumberInteger _int)
		{
			return new ResultNumberReal(_int.ToDouble());
		}
	}
}
