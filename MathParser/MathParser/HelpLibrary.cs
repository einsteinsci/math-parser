using MathParser.Functions;
using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
	public static class HelpLibrary
	{
		private static Dictionary<string, string> library = new Dictionary<string, string>();

		static HelpLibrary()
		{
			Init();
		}

		public static void Init()
		{
			library.Clear();

			RegisterHelp("sin", "Real sin(Real)\n - Returns the sine of a value");
			RegisterHelp("cos", "Real cos(Real)\n - Returns the cosine of a value");
			RegisterHelp("tan", "Real tan(Real)\n - Returns the tangent of a value");
			RegisterHelp("csc", "Real csc(Real)\n - Returns the cosecant of a value");
			RegisterHelp("sec", "Real sec(Real)\n - Returns the secant of a value");
			RegisterHelp("cot", "Real cot(Real)\n - Returns the cotangent of a value");
			RegisterHelp("asin", "Real asin(Real)\n - Returns the inverse sine (arcsine) of an angle");
			RegisterHelp("acos", "Real acos(Real)\n - Returns the inverse cosine (arccosine) of an angle");
			RegisterHelp("atan", "Real atan(Real)\n - Returns the inverse tangent (arctangent) of an angle");

			RegisterHelp("logn", "Real logn(Real x, Real n)\n - Returns the base-n logarithm of x");
			RegisterHelp("ln", "Real ln(Real)\n - Returns the base-e (natural) logarithm of a value");
			RegisterHelp("log", "Real log(Real)\n - Returns the base-10 logarithm of a value");

			RegisterHelp("abs", "Real abs(Real)\n - Returns the absolute value of a value");
			RegisterHelp("sign", "Real sign(Real)\n - Returns the sign of a number: -1 if negative, 0 if zero, 1 if positive.");

			RegisterHelp("max", "Real max(Real, Real)\n - Returns the higher of two values");
			RegisterHelp("min", "Real min(Real, Real)\n - Returns the lower of two values");

			RegisterHelp("substring", "String substring(String str, Integer start, Integer len)\n" +
				" - Returns the substring of str starting from index start, len characters long");

			RegisterHelp("help", "String help(string funcName)\n - Returns information on a function, like this");

			RegisterHelp("minl", "Real minl(List)\n - Returns the lowest value of the list");
			RegisterHelp("maxl", "Real maxl(List)\n - Returns the highest value of the list");
			RegisterHelp("mean", "Real mean(List)\n - Returns the mean of all the values in the list");
			RegisterHelp("sd", "Real sd(List)\n - Returns the standard deviation of all the values in the list");
			RegisterHelp("rms", "Real rms(list)\n - Returns the root-mean-square value of the list");
		}

		public static void RegisterHelp(string functionName, string help)
		{
			if (library.ContainsKey(functionName))
			{
				Logger.Log(LogLevel.Info, Logger.REGISTRY,
					"Existing help found for function '" + functionName +
					"'. Replacing help data.");
				library[functionName] = help;
			}
			else
			{
				library.Add(functionName, help);
			}
		}
		public static void RegisterHelp(FunctionInfo info, string help)
		{
			RegisterHelp(info.Name, help);
		}

		public static string GetHelp(string functionName)
		{
			if (!library.ContainsKey(functionName))
			{
				return "No help found for '" + functionName + "'";
			}

			return library[functionName];
		}
	}
}
