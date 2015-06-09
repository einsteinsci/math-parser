using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathPlusLib;

namespace MathParser.Types
{
	/// <summary>
	/// Enum representing all evaluatable types in the library
	/// </summary>
	public enum MathType
	{
		/// <summary>
		/// A real number. Equivalent to a double.
		/// </summary>
		Real = 0,
		/// <summary>
		/// An integer. Equivalent to an int.
		/// </summary>
		Integer,
		/// <summary>
		/// A string of text. Equivalent to a string.
		/// </summary>
		String,
		/// <summary>
		/// A boolean value. Equivalent to a bool.
		/// </summary>
		Boolean,
		/// <summary>
		/// A list of numbers. Equivalent to a List&lt;double&gt;
		/// </summary>
		List
	}

	/// <summary>
	/// Specifies methods involving the conversion between MathType and System.Type.
	/// </summary>
	public static class MathTypes
	{
		/// <summary>
		/// Converts a System.Type to a MathType.
		/// </summary>
		public static MathType ToMathType(this Type type)
		{
			if (type == typeof(double) || type == typeof(float))
			{
				return MathType.Real;
			}
			else if (type == typeof(long) || type == typeof(int) || type == typeof(short))
			{
				return MathType.Integer;
			}
			else if (type == typeof(string))
			{
				return MathType.String;
			}
			else if (type == typeof(bool))
			{
				return MathType.Boolean;
			}
			else if (type == typeof(List<double>) || type == typeof(double[]) ||
				type == typeof(List<float>) || type == typeof(float[]))
			{
				return MathType.List;
			}
			else
			{
				throw new ArgumentException("No recognized MathType for " + type.ToString());
			}
		}

		/// <summary>
		/// Converts a MathTYpe to a System.Type.
		/// </summary>
		public static Type ToSystemType(this MathType mtype)
		{
			switch (mtype)
			{
			case MathType.Real:
				return typeof(double);
			case MathType.Integer:
				return typeof(long);
			case MathType.String:
				return typeof(string);
			case MathType.Boolean:
				return typeof(bool);
			case MathType.List:
				return typeof(List<double>);
			default:
				throw new ArgumentException("Not a valid MathType: " + mtype.ToString());
			}
		}
	}
}
