using MathPlusLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Types
{
	/// <summary>
	/// Represents a string of characters. Ironically there is
	/// no character type in this parser.
	/// </summary>
	public sealed class ResultString : IResultValue
	{
		/// <summary>
		/// Type of value stored within the result
		/// </summary>
		public MathType Type
		{ get { return MathType.String; } }

		/// <summary>
		/// Internal object held, storing the result's data
		/// </summary>
		public object CoreValue
		{ get { return Value; } }

		/// <summary>
		/// Internal string stored
		/// </summary>
		public string Value
		{ get; set; }

		/// <summary>
		/// Instantiates a new ResultString
		/// </summary>
		public ResultString(string s)
		{
			Value = s;
		}

		/// <summary>
		/// Converts the result to a double.
		/// </summary>
		public decimal ToDecimal()
		{
			return decimal.Parse(Value);
		}

		/// <summary>
		/// Converts the result to an int
		/// </summary>
		public long ToInteger()
		{
			return long.Parse(Value);
		}

		/// <summary>
		/// Converts the result to a bool
		/// </summary>
		public bool ToBoolean()
		{
			int nothing = 0;
			if (Value == "0" || Value.ToLower() == "false")
			{
				return false;
			}
			else if (int.TryParse(Value, out nothing) || Value.ToLower() == "true")
			{
				return true;
			}
			else
			{
				throw new InvalidCastException("Cannot convert " + ToDisplayString() + " to Boolean.");
			}
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
			return "\"" + Value + "\"";
		}

		/// <summary>
		/// Converts the result to a string
		/// </summary>
		public override string ToString()
		{
			return Value;
		}
	}
}
