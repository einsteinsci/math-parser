using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathPlusLib;

namespace MathParser.Types
{
	public enum MathType
	{
		Real = 0,
		Integer,
		String,
		Boolean,
		List,
		Matrix
	}


	public static class MathTypes
	{
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
			else if (type == typeof(MathMatrix))
			{
				return MathType.Matrix;
			}
			else
			{
				throw new ArgumentException("No recognized MathType for " + type.ToString());
			}
		}

		public static Type ToCodeType(this MathType mtype)
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
			case MathType.Matrix:
				return typeof(MathMatrix);
			default:
				throw new ArgumentException("Not a valid MathType: " + mtype.ToString());
			}
		}
	}
}
