using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathPlusLib;

namespace MathParser.ParseTree
{
	public sealed class FunctionInfo
	{
		public string Name
		{ get; private set; }

		public Type[] Arguments
		{ get; private set; }

		public Func<object[], double> Evaluate
		{ get; private set; }

		public FunctionInfo(string name, Type[] args, Func<object[], double> func)
		{
			Name = name;
			Arguments = args;
			Evaluate = func;
		}
	}

	public static class MathFunctions
	{
		public static FunctionInfo Sine = new FunctionInfo("sin",
			new Type[] { typeof(double) }, (args) => MathPlus.Trig.Sin((double)args[0]));

		public static List<FunctionInfo> AllFunctions
		{ get; private set; }

		static MathFunctions()
		{
			AllFunctions = new List<FunctionInfo>();

			AllFunctions.Add(Sine);
		}
	}
}
