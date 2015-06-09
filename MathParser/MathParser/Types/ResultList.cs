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
		public List<double> Value
		{ get; private set; }

		/// <summary>
		/// Instantiates a new ResultList.
		/// </summary>
		public ResultList(List<double> value)
		{
			Value = value;
		}
		/// <summary>
		/// Instantiates a new ResultList.
		/// </summary>
		public ResultList() : this(new List<double>())
		{ }
		/// <summary>
		/// Instantiates a new ResultList.
		/// </summary>
		public ResultList(params double[] value) : this(value.ToList())
		{ }

		/// <summary>
		/// Converts the result to a double.
		/// </summary>
		public double ToDouble()
		{
			return Value.FirstOrDefault();
		}

		/// <summary>
		/// Converts the result to an int
		/// </summary>
		public long ToInteger()
		{
			return (long)ToDouble();
		}

		/// <summary>
		/// Converts the result to a bool
		/// </summary>
		public bool ToBoolean()
		{
			return ToDouble() != 0;
		}

		/// <summary>
		/// Converts the result to a list
		/// </summary>
		public List<double> ToList()
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
