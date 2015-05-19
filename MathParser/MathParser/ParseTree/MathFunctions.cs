using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathPlusLib;
using System.Reflection;

namespace MathParser.ParseTree
{
	public static class MathFunctions
	{
		public static List<FunctionInfo> AllFunctions
		{ get; private set; }

		#region functions

		public static FunctionInfo Sine
		{ get { return sine; } }
		private static FunctionInfo sine = new FunctionInfo(
			(Func<double, double>)MathPlus.Trig.Sin, 
			MathType.Number, "sin", MathType.Number);

		public static FunctionInfo Cosine
		{ get { return cosine; } }
		private static FunctionInfo cosine = new FunctionInfo(
			(Func<double, double>)MathPlus.Trig.Cos, 
			MathType.Number, "cos", MathType.Number);

		public static FunctionInfo Tangent
		{ get { return tangent; } }
		private static FunctionInfo tangent = new FunctionInfo(
			(Func<double, double>)MathPlus.Trig.Tan, 
			MathType.Number, "tan", MathType.Number);

		public static FunctionInfo Cosecant
		{ get { return cosecant; } }
		private static FunctionInfo cosecant = new FunctionInfo(
			(Func<double, double>)MathPlus.Trig.Csc, 
			MathType.Number, "csc", MathType.Number);

		public static FunctionInfo Secant
		{ get { return secant; } }
		private static FunctionInfo secant = new FunctionInfo(
			(Func<double, double>)MathPlus.Trig.Sec, 
			MathType.Number, "sec", MathType.Number);

		public static FunctionInfo Cotangent
		{ get { return cotangent; } }
		private static FunctionInfo cotangent = new FunctionInfo(
			(Func<double, double>)MathPlus.Trig.Cot, 
			MathType.Number, "cot", MathType.Number);

		public static FunctionInfo LogarithmN
		{ get { return logarithmN; } }
		private static FunctionInfo logarithmN = new FunctionInfo(
			(Func<double, double, double>)MathPlus.Log, 
			MathType.Number, "logn", MathType.Number, MathType.Number);

		public static FunctionInfo LogarithmE
		{ get { return logarithmE; } }
		private static FunctionInfo logarithmE = new FunctionInfo(
			(Func<double, double>)MathPlus.Ln, 
			MathType.Number, "ln", MathType.Number);

		public static FunctionInfo Logarithm
		{ get { return logarithm; } }
		private static FunctionInfo logarithm = new FunctionInfo(
			(Func<double, double>)MathPlus.Log10, 
			MathType.Number, "log", MathType.Number);

		public static FunctionInfo AbsoluteVal
		{ get { return absoluteVal; } }
		private static FunctionInfo absoluteVal = new FunctionInfo(
			(Func<double, double>)MathPlus.Abs, 
			MathType.Number, "abs", MathType.Number);

		public static FunctionInfo Sign
		{ get { return sign; } }
		private static FunctionInfo sign = new FunctionInfo(
			(Func<double, double>)((d) => MathPlus.Sign(d)),
			MathType.Number, "sign", MathType.Number);

		public static FunctionInfo Max
		{ get { return max; } }
		private static FunctionInfo max = new FunctionInfo(
			(Func<double, double, double>)MathPlus.Max,
			MathType.Number, "max", MathType.Number, MathType.Number);

		public static FunctionInfo Min
		{ get { return min; } }
		private static FunctionInfo min = new FunctionInfo(
			(Func<double, double, double>)MathPlus.Min,
			MathType.Number, "min", MathType.Number, MathType.Number);

		#endregion

		public static FunctionInfo GetFunction(string name)
		{
			foreach (FunctionInfo inf in AllFunctions)
			{
				if (inf.Name.ToLower() == name.ToLower())
				{
					return inf;
				}
			}

			return null;
		}

		static MathFunctions()
		{
			AllFunctions = new List<FunctionInfo>();

			AllFunctions.Add(Sine);
			AllFunctions.Add(Cosine);
			AllFunctions.Add(Tangent);
			AllFunctions.Add(Cosecant);
			AllFunctions.Add(Secant);
			AllFunctions.Add(Cotangent);

			AllFunctions.Add(Logarithm);
			AllFunctions.Add(LogarithmE);
			AllFunctions.Add(LogarithmN);

			AllFunctions.Add(AbsoluteVal);
			AllFunctions.Add(Sign);

			AllFunctions.Add(Max);
			AllFunctions.Add(Min);
		}
	}
}
