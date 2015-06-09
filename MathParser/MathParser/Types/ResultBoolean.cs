using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathPlusLib;

namespace MathParser.Types
{
	/// <summary>
	/// Represents a boolean value
	/// </summary>
	public sealed class ResultBoolean : IResultValue
	{
		/// <summary>
		/// Internal object held, storing the result's data
		/// </summary>
		public object CoreValue
		{ get { return Value; } }

		/// <summary>
		/// Internal bool storing true or false.
		/// </summary>
		public bool Value
		{ get; set; }

		/// <summary>
		/// Type of value stored within the result
		/// </summary>
		public MathType Type
		{ get { return MathType.Boolean; } }

		/// <summary>
		/// Instantiates a new ResultBoolean
		/// </summary>
		public ResultBoolean(bool value)
		{
			Value = value;
		}

		/// <summary>
		/// Gets the display string of the object
		/// </summary>
		public string ToDisplayString()
		{
			return ToString();
		}

		/// <summary>
		/// Converts the result to a double.
		/// </summary>
		public double ToDouble()
		{
			return (double)ToInteger();
		}

		/// <summary>
		/// Converts the result to an int
		/// </summary>
		public long ToInteger()
		{
			return Value ? 1 : 0;
		}

		/// <summary>
		/// Converts the result to a bool
		/// </summary>
		public bool ToBoolean()
		{
			return Value;
		}

		/// <summary>
		/// Converts the result to a list
		/// </summary>
		public List<double> ToList()
		{
			return new List<double>() { ToDouble() };
		}

		/// <summary>
		/// Converts the result to a string
		/// </summary>
		public override string ToString()
		{
			return Value ? "true" : "false";
		}
	}
}
