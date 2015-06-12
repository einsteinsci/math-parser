using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Functions;

namespace MathParser.Test
{
	[FunctionLibrary]
	public static class TestFuncLib
	{
		[MathFunction("three")]
		public static int Three()
		{
			return 3;
		}

		[MathFunction("plustwo")]
		public static double PlusTwo(float f)
		{
			return f + 2;
		}
	}
}
