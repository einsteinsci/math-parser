using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathPlusLib;
using MathParser.Lexing;
using MathParser.Types;

namespace MathParser.Functions
{
	/// <summary>
	/// Various numeric functions
	/// </summary>
	[FunctionLibrary("numeric")]
	public static class LibraryNumeric
	{
		/// <summary>
		/// Returns the base-n logarithm of a number
		/// </summary>
		[MathFunction("logn")]
		public static double LogarithmN(double val, double baseNum)
		{
			return MathPlus.Log(val, baseNum);
		}

		/// <summary>
		/// Returns the natural (base e) logarithm of a number
		/// </summary>
		[MathFunction("ln")]
		public static double LogarithmE(double val)
		{
			return MathPlus.Ln(val);
		}

		/// <summary>
		/// Returns the base 10 logarithm of a number
		/// </summary>
		[MathFunction("log")]
		public static double Logarithm(double val)
		{
			return MathPlus.Log10(val);
		}

		/// <summary>
		/// Absolute value function
		/// </summary>
		[MathFunction("abs")]
		public static double AbsoluteValue(double val)
		{
			return MathPlus.Abs(val);
		}

		/// <summary>
		/// Sign (not sine) of a number:
		/// -1 if negative, 0 if zero, 1 if positive
		/// </summary>
		[MathFunction("sign")]
		public static double Sign(double val)
		{
			return MathPlus.Sign(val);
		}

		/// <summary>
		/// Square root function
		/// </summary>
		[MathFunction("sqrt")]
		public static double SquareRoot(double val)
		{
			return MathPlus.Sqrt(val);
		}

		/// <summary>
		/// Maximum of two values
		/// </summary>
		[MathFunction("max")]
		public static double Maximum(double a, double b)
		{
			return MathPlus.Max(a, b);
		}

		/// <summary>
		/// Minimum of two values
		/// </summary>
		[MathFunction("min")]
		public static double Minimum(double a, double b)
		{
			return MathPlus.Min(a, b);
		}

		/// <summary>
		/// Random number between 0 and 1
		/// </summary>
		[MathFunction("rand")]
		public static double Random()
		{
			return MathPlus.Probability.Rand.NextDouble();
		}

		/// <summary>
		/// Random integer given a minimum and exclusive maximum
		/// </summary>
		[MathFunction("randint")]
		public static int RandomInteger(int min, int max)
		{
			return MathPlus.Probability.Rand.Next(min, max);
		}
	}
}
