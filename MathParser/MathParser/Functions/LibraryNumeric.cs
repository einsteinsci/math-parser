using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathPlusLib;

namespace MathParser.Functions
{
	[FunctionLibrary("numeric")]
	public static class LibraryNumeric
	{
		[Function]
		public static FunctionInfo LogarithmN
		{ get { return logarithmN; } }
		private static FunctionInfo logarithmN = new FunctionInfo(
			(Func<double, double, double>)MathPlus.Log,
			MathType.Real, "logn", MathType.Real, MathType.Real);

		[Function]
		public static FunctionInfo LogarithmE
		{ get { return logarithmE; } }
		private static FunctionInfo logarithmE = new FunctionInfo(
			(Func<double, double>)MathPlus.Ln,
			MathType.Real, "ln", MathType.Real);

		[Function]
		public static FunctionInfo Logarithm
		{ get { return logarithm; } }
		private static FunctionInfo logarithm = new FunctionInfo(
			(Func<double, double>)MathPlus.Log10,
			MathType.Real, "log", MathType.Real);

		[Function]
		public static FunctionInfo AbsoluteVal
		{ get { return absoluteVal; } }
		private static FunctionInfo absoluteVal = new FunctionInfo(
			(Func<double, double>)MathPlus.Abs,
			MathType.Real, "abs", MathType.Real);

		[Function]
		public static FunctionInfo Sign
		{ get { return sign; } }
		private static FunctionInfo sign = new FunctionInfo(
			(Func<double, double>)((d) => MathPlus.Sign(d)),
			MathType.Real, "sign", MathType.Real);

		[Function]
		public static FunctionInfo Max
		{ get { return max; } }
		private static FunctionInfo max = new FunctionInfo(
			(Func<double, double, double>)MathPlus.Max,
			MathType.Real, "max", MathType.Real, MathType.Real);

		[Function]
		public static FunctionInfo Min
		{ get { return min; } }
		private static FunctionInfo min = new FunctionInfo(
			(Func<double, double, double>)MathPlus.Min,
			MathType.Real, "min", MathType.Real, MathType.Real);

		[Function]
		public static FunctionInfo Random
		{ get { return random; } }
		private static FunctionInfo random = new FunctionInfo(
			(Func<double>)(() => MathPlus.Probability.Rand.NextDouble()),
			MathType.Real, "rand");

		[Function]
		public static FunctionInfo RandInt
		{ get { return randInt; } }
		private static FunctionInfo randInt = new FunctionInfo(
			(Func<long, long, double>)((a, b) => MathPlus.Probability.Rand.Next((int)a, (int)b)),
			MathType.Real, "randint", MathType.Integer, MathType.Integer);
	}
}
