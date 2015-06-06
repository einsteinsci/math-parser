using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathPlusLib;

namespace MathParser.Functions
{
	[FunctionLibrary("trig")]
	public class LibraryTrig
	{
		[Function]
		public static FunctionInfo Sine
		{ get { return sine; } }
		private static FunctionInfo sine = new FunctionInfo(
			(Func<double, double>)MathPlus.Trig.Sin,
			MathType.Real, "sin", MathType.Real);

		[Function]
		public static FunctionInfo Cosine
		{ get { return cosine; } }
		private static FunctionInfo cosine = new FunctionInfo(
			(Func<double, double>)MathPlus.Trig.Cos,
			MathType.Real, "cos", MathType.Real);

		[Function]
		public static FunctionInfo Tangent
		{ get { return tangent; } }
		private static FunctionInfo tangent = new FunctionInfo(
			(Func<double, double>)MathPlus.Trig.Tan,
			MathType.Real, "tan", MathType.Real);

		[Function]
		public static FunctionInfo Cosecant
		{ get { return cosecant; } }
		private static FunctionInfo cosecant = new FunctionInfo(
			(Func<double, double>)MathPlus.Trig.Csc,
			MathType.Real, "csc", MathType.Real);

		[Function]
		public static FunctionInfo Secant
		{ get { return secant; } }
		private static FunctionInfo secant = new FunctionInfo(
			(Func<double, double>)MathPlus.Trig.Sec,
			MathType.Real, "sec", MathType.Real);

		[Function]
		public static FunctionInfo Cotangent
		{ get { return cotangent; } }
		private static FunctionInfo cotangent = new FunctionInfo(
			(Func<double, double>)MathPlus.Trig.Cot,
			MathType.Real, "cot", MathType.Real);

		[Function]
		public static FunctionInfo ArcSine
		{ get { return arcSine; } }
		private static FunctionInfo arcSine = new FunctionInfo(
			(Func<double, double>)MathPlus.Trig.ASin,
			MathType.Real, "asin", MathType.Real);

		[Function]
		public static FunctionInfo ArcCosine
		{ get { return arcCosine; } }
		private static FunctionInfo arcCosine = new FunctionInfo(
			(Func<double, double>)MathPlus.Trig.ACos,
			MathType.Real, "acos", MathType.Real);

		[Function]
		public static FunctionInfo ArcTangent
		{ get { return arcTangent; } }
		private static FunctionInfo arcTangent = new FunctionInfo(
			(Func<double, double>)MathPlus.Trig.ATan,
			MathType.Real, "atan", MathType.Real);
	}
}
