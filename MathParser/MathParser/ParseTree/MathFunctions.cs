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
		}
	}
}
