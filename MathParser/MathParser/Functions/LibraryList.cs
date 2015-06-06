using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathPlusLib;

namespace MathParser.Functions
{
	[FunctionLibrary("list")]
	public static class LibraryList
	{
		[Function]
		public static FunctionInfo MaxList
		{ get { return maxList; } }
		private static FunctionInfo maxList = new FunctionInfo(
			(Func<List<double>, double>)((list) => MathPlus.Max(list)),
			MathType.Real, "maxl", MathType.List);

		[Function]
		public static FunctionInfo MinList
		{ get { return minList; } }
		private static FunctionInfo minList = new FunctionInfo(
			(Func<List<double>, double>)((list) => MathPlus.Min(list)),
			MathType.Real, "minl", MathType.List);

		[Function]
		public static FunctionInfo Mean
		{ get { return mean; } }
		private static FunctionInfo mean = new FunctionInfo(
			(Func<List<double>, double>)((list) => MathPlus.Stats.Mean(list)),
			MathType.Real, "mean", MathType.List);

		[Function]
		public static FunctionInfo StdDev
		{ get { return stdDev; } }
		private static FunctionInfo stdDev = new FunctionInfo(
			(Func<List<double>, double>)((list) => MathPlus.Stats.StandardDev(list)),
			MathType.Real, "sd", MathType.List);

		[Function]
		public static FunctionInfo RootMeanSquare
		{ get { return rootMeanSquare; } }
		private static FunctionInfo rootMeanSquare = new FunctionInfo(
			(Func<List<double>, double>)((list) => MathPlus.Stats.RootMeanSquare(list)),
			MathType.Real, "rms", MathType.List);
	}
}
