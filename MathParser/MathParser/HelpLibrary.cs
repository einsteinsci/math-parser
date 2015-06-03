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
