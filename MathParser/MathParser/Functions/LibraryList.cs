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
	/// Functions relating to lists
	/// </summary>
	[FunctionLibrary]
	public static class LibraryList
	{
		/// <summary>
		/// Returns the maximum value in a list
		/// </summary>
		[MathFunction("maxl")]
		public static double MaxList(List<double> list)
		{
			return MathPlus.Max(list);
		}

		/// <summary>
		/// Returns the minimum value in a list
		/// </summary>
		[MathFunction("minl")]
		public static double MinList(List<double> list)
		{
			return MathPlus.Min(list);
		}

		/// <summary>
		/// Returns the mean value of a list
		/// </summary>
		[MathFunction("mean")]
		public static double Mean(List<double> list)
		{
			return MathPlus.Stats.Mean(list);
		}

		/// <summary>
		/// Returns the standard deviation of a list
		/// </summary>
		[MathFunction("sd")]
		public static double StandardDeviation(List<double> list)
		{
			return MathPlus.Stats.StandardDev(list);
		}

		/// <summary>
		/// Returns the root-mean-square value of a list
		/// </summary>
		[MathFunction("rms")]
		public static double RootMeanSquare(List<double> list)
		{
			return MathPlus.Stats.RootMeanSquare(list);
		}

		/// <summary>
		/// Returns the size of a list (in elements)
		/// </summary>
		[MathFunction("sizeof")]
		public static int SizeOf(List<double> list)
		{
			return list.Count;
		}

		/// <summary>
		/// Creates a new list of a given size, filled with a given value
		/// </summary>
		[MathFunction("fill")]
		public static List<double> Fill(double val, long count)
		{
			List<double> res = new List<double>();
			for (int i = 0; i < count; i++)
			{
				res.Add(val);
			}

			return res;
		}

		/// <summary>
		/// Returns a list containing the cumulative sum of a list over its elements
		/// </summary>
		[MathFunction("cumsum")]
		public static List<double> CumulativeSum(List<double> list)
		{
			List<double> res = new List<double>();
			double total = 0;
			foreach (double d in list)
			{
				total += d;
				res.Add(total);
			}

			return res;
		}
	}
}
