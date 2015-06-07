using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Lexing;
using MathParser.Types;

namespace MathParser.Functions
{
	/// <summary>
	/// Functions involving strings
	/// </summary>
	[FunctionLibrary("string")]
	public static class LibraryString
	{
		/// <summary>
		/// Substring of a given string, given a start index and length
		/// </summary>
		[MathFunction("substring")]
		public static string Substring(string str, int start, int len)
		{
			return str.Substring(start, len);
		}

		/// <summary>
		/// Provides help on any given function name
		/// </summary>
		[MathFunction("help")]
		public static string Help(string funcName)
		{
			return HelpLibrary.GetHelp(funcName);
		}
	}
}
