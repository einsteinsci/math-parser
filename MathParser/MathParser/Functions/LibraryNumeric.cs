using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathPlusLib;
using MathParser.Lexing;
using MathParser.Types;
using MathPlusLib.Extensions;

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
			return val.Abs();
		}

		/// <summary>
		/// Sign (not sine) of a number:
		/// -1 if negative, 0 if zero, 1 if positive
		/// </summary>
		[MathFunction("sign")]
		public static double Sign(double val)
		{
			return val.Sign();
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
		/// Generic root function
		/// </summary>
		[MathFunction("root")]
		public static double NthRoot(double radicand, double radical)
		{
			return MathPlus.Root(radicand, radical);
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
		/// Returns a constrained value between a minimum and maximum.
		/// </summary>
		[MathFunction("constrain")]
		public static double Constrain(double value, double min, double max)
		{
			return value.Constrain(min, max);
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
		[MathFunction("randInt")]
		public static int RandomInteger(int min, int max)
		{
			return MathPlus.Probability.Rand.Next(min, max);
		}

		/// <summary>
		/// Returns the integral part of a number (the '3' of 3.86)
		/// </summary>
		[MathFunction("int")]
		public static int IntegralPart(double val)
		{
			return (int)val;
		}

		/// <summary>
		/// Returns the fractional part of a number (the '.86' part of 3.86)
		/// </summary>
		[MathFunction("frac")]
		public static double FractionalPart(double val)
		{
			return val.Fractional();
		}

		/// <summary>
		/// Returns the least common multiple (LCM) of two values.
		/// </summary>
		[MathFunction("lcm")]
		public static int LeastCommonMultiple(int a, int b)
		{
			return MathPlus.Numerics.LeastCommonMultiple(a, b);
		}

		/// <summary>
		/// Rounds a number to the nearest n decimal places
		/// </summary>
		[MathFunction("round")]
		public static double Round(double value, int n)
		{
			return value.Round(n);
		}

		/// <summary>
		/// Rounds a number up.
		/// </summary>
		[MathFunction("ceiling")]
		public static int Ceiling(double value)
		{
			return value.Ceiling();
		}

		/// <summary>
		/// Rounds a number down.
		/// </summary>
		[MathFunction("floor")]
		public static int Floor(double value)
		{
			return value.Floor();
		}

		/// <summary>
		/// Permutation function
		/// </summary>
		[MathFunction("nPr")]
		public static long Permutation(long n, long r)
		{
			return MathPlus.Probability.Permutation(n, r);
		}

		/// <summary>
		/// Combination function
		/// </summary>
		[MathFunction("nCr")]
		public static long Combination(long n, long r)
		{
			return MathPlus.Probability.Combination(n, r);
		}

		/// <summary>
		/// Random integer list, no repeats. Returns a double
		/// as MathType.List only corresponds with lists of doubles.
		/// </summary>
		[MathFunction("randIntsNoRep")]
		public static List<double> RandomIntsNoRep(int min, int max, int count)
		{
			return MathPlus.Probability.RandomIntsNoRepeat(min, max, count)
				.Select<int, double>(n => n).ToList();
		}
	}
}
