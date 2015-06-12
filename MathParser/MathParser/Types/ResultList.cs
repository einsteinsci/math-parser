using MathPlusLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Types
{
	/// <summary>
	/// Represents a list of numbers
	/// </summary>
	public sealed class ResultList : IResultValue
	{
		/// <summary>
		/// Type of value stored within the result
		/// </summary>
		public MathType Type
		{ get { return MathType.List; } }

		/// <summary>
		/// Internal object held, storing the result's data
		/// </summary>
		public object CoreValue
		{ get { return Value; } }

		/// <summary>
		/// Internal number list stored.
		/// </summary>
		public List<decimal> Value
		{ get; private set; }

		/// <summary>
		/// Instantiates a new ResultList.
		/// </summary>
		public ResultList(List<decimal> value)
		{
			Value = value;
		}
		/// <summary>
		/// Instantiates a new ResultList.
		/// </summary>
		public ResultList() : this(new List<decimal>())
		{ }
		/// <summary>
		/// Instantiates a new ResultList.
		/// </summary>
		public ResultList(params decimal[] value) : this(value.ToList())
		{ }

		/// <summary>
		/// Converts the result to a double.
		/// </summary>
		public decimal ToDecimal()
		{
			throw new InvalidCastException("Cannot convert List to Real.");
		}

		/// <summary>
		/// Converts the result to an int
		/// </summary>
		public long ToInteger()
		{
			throw new InvalidCastException("Cannot convert List to Integer.");
		}

		/// <summary>
		/// Converts the result to a bool
		/// </summary>
		public bool ToBoolean()
		{
			throw new InvalidCastException("Cannot convert List to Boolean.");
		}

		/// <summary>
		/// Converts the result to a list
		/// </summary>
		public List<decimal> ToList()
		{
			return Value;
		}

		/// <summary>
		/// Gets the display string of the object
		/// </summary>
		public string ToDisplayString()
		{
			return ToString();
		}

		/// <summary>
		/// Converts the result to a string
		/// </summary>
		public override string ToString()
		{
			string res = "{ ";
			for (int i = 0; i < Value.Count; i++)
			{
				res += Value[i].ToString();

				if (i < Value.Count - 1)
				{
					res += ", ";
				}
			}

			return res + " }";
		}
	}
}
