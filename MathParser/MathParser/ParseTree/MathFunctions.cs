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
		}
	}
}
