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
	[FunctionLibrary("list")]
	public static class LibraryList
	{
		[MathFunction("maxl")]
		public static double MaxList(List<double> list)
		{
			return MathPlus.Max(list);
		}

		[MathFunction("minl")]
		public static double MinList(List<double> list)
		{
			return MathPlus.Min(list);
		}

		[MathFunction("mean")]
		public static double Mean(List<double> list)
		{
			return MathPlus.Stats.Mean(list);
		}

		[MathFunction("sd")]
		public static double StandardDeviation(List<double> list)
		{
			return MathPlus.Stats.StandardDev(list);
		}

		[MathFunction("rms")]
		public static double RootMeanSquare(List<double> list)
		{
			return MathPlus.Stats.RootMeanSquare(list);
		}

		[MathFunction("sizeof")]
		public static int SizeOf(List<double> list)
		{
			return list.Count;
		}

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
