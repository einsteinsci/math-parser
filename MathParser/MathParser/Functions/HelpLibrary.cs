using MathParser.Functions;
using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Functions
{
	/// <summary>
	/// Library for help info on each function
	/// </summary>
	public static class HelpLibrary
	{
		private static bool hasRegistered = false;

		private static Dictionary<string, string> library = new Dictionary<string, string>();

		static HelpLibrary()
		{
			Init();
		}

		/// <summary>
		/// Initializes the help library
		/// </summary>
		public static void Init(bool force = false)
		{
			if (hasRegistered && !force)
			{
				return;
			}

			library.Clear();

			RegisterHelp("sqrt", "Real sqrt(Real)\n - Returns the square root of a value");
			RegisterHelp("root", "Real root(Real val, Real n)\n - Returns the nth root of val");

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
			RegisterHelp("sign", "Real sign(Real)\n - Returns the sign of a number:" + 
				" -1 if negative, 0 if zero, 1 if positive.");
			RegisterHelp("int", "Real int(Real)\n - Returns the integral part of a number");
			RegisterHelp("frac", "Real frac(Real)\n - Returns the fractional part of a number");
			RegisterHelp("lcm", "Integer lcm(Integer, Integer)\n - Returns the lowest common multiple of two numbers");
			RegisterHelp("round", "Real round(Real val, Integer n)\n - Rounds val to the nearest n decimal places");
			RegisterHelp("ceiling", "Integer ceiling(Real)\n - Rounds a number up");
			RegisterHelp("floor", "Integer floor(Real)\n - Rounds a number down");

			RegisterHelp("rand", "Real rand()\n - Returns a random number between 0 and 1");
			RegisterHelp("randInt", "Integer rand(int min, int max)\n" +
				" - Returns a random bound by an inclusive minimum and exclusive maximum");
			RegisterHelp("nPr", "Integer nPr(Integer n, Integer r)\n - Permutation function");
			RegisterHelp("nCr", "Integer nCr(Integer n, Integer r)\n - Combination function");
			RegisterHelp("randIntsNoRep", "List randIntsNoRep(Integer min, Integer max, Integer n)\n" +
				" - Returns a list of n integers in the range [min, max)");

			RegisterHelp("max", "Real max(Real, Real)\n - Returns the higher of two values");
			RegisterHelp("min", "Real min(Real, Real)\n - Returns the lower of two values");
			RegisterHelp("constrain", "Real constrain(Real val, Real min, Real max)\n" + 
				" - Constrains val to between min and max");

			RegisterHelp("substring", "String substring(String str, Integer start, Integer len)\n" +
				" - Returns the substring of str starting from index start, len characters long");

			RegisterHelp("help", "String help(string funcName)\n - Returns information on a function, like this");

			RegisterHelp("minl", "Real minl(List)\n - Returns the lowest value of the list");
			RegisterHelp("maxl", "Real maxl(List)\n - Returns the highest value of the list");
			RegisterHelp("mean", "Real mean(List)\n - Returns the mean of all the values in the list");
			RegisterHelp("sd", "Real sd(List)\n - Returns the standard deviation of all the values in the list");
			RegisterHelp("rms", "Real rms(list)\n - Returns the root-mean-square value of the list");

			hasRegistered = true;
		}

		/// <summary>
		/// Registers a function for the library
		/// </summary>
		/// <param name="functionName">Name of function in library</param>
		/// <param name="help">Information on function</param>
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
		/// <summary>
		/// Registers help for a function in the library
		/// </summary>
		/// <param name="info">FunctionInfo designating function referenced</param>
		/// <param name="help">Help info on function</param>
		public static void RegisterHelp(FunctionInfo info, string help)
		{
			RegisterHelp(info.Name, help);
		}

		/// <summary>
		/// Gets the help stored for a function name
		/// </summary>
		/// <param name="functionName">Name of function</param>
		/// <returns>Help on given function</returns>
		public static string GetHelp(string functionName)
		{
			if (!library.ContainsKey(functionName))
			{
				return "No help found for '" + functionName + "'";
			}

			return library[functionName];
		}

		/// <summary>
		/// Lists all functions registered in the help library into a big table-like string.
		/// </summary>
		public static string ListFunctions()
		{
			string res = "";
			int col = 0;
			foreach (string funcName in library.Keys)
			{
				res += funcName + "\t";
				if (funcName.Length <= 8)
				{
					res += "\t";
				}
				col++;

				if (col == 4)
				{
					res = res.TrimEnd('\t');
					res += "\n";
					col = 0;
				}
			}

			return res.TrimEnd('\t', '\n');
		}
	}
}
