using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Functions
{
	[FunctionLibrary("string")]
	public static class LibraryString
	{
		[Function]
		public static FunctionInfo Substring
		{ get { return substring; } }
		private static FunctionInfo substring = new FunctionInfo(
			(Func<string, long, long, string>)((string str, long start, long len) =>
				str.Substring((int)start, (int)len)),
			MathType.String, "substring", MathType.String, MathType.Integer, MathType.Integer);

		[Function]
		public static FunctionInfo Help
		{ get { return help; } }
		private static FunctionInfo help = new FunctionInfo(
			(Func<string, string>)HelpLibrary.GetHelp,
			MathType.String, "help", MathType.String);
	}
}
