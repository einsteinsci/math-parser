using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathPlusLib;

namespace MathParser.ParseTree
{
	public sealed class MathFunc<T>
	{
		public string Name
		{ get; private set; }

		public Type[] Arguments
		{ get; private set; }

		public Func<object[], T> Evaluate
		{ get; private set; }

		public MathFunc(string name, Type[] args, Func<object[], T> func)
		{
			Name = name;
			Arguments = args;
			Evaluate = func;
		}
	}

	public static class MathFunctions
	{
		public static MathFunc<double> Sine = new MathFunc<double>(
			"sin", new Type[] { typeof(double) }, (args) => MathPlus.Trig.Sin((double)args[0]));
	}
}
