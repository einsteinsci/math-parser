using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
	public enum LogLevel
	{
		Debug = -1,
		Info = 0,
		Warning,
		Error,
		Fatal
	}

	public static class Logger
	{
		public static event Action<LogLevel, string> OnLog;

		public const string LEXER = "tokenize";
		public const string PARSER = "parse";
		public const string EVALUATOR = "evaluate";
		public const string REGISTRY = "register";

		public static bool DebugLogging
		{ get; set; }

		public static List<string> DisabledCategories
		{ get; private set; }

		static Logger()
		{
			DebugLogging = true;
			DisabledCategories = new List<string>();
		}

		public static void Log(LogLevel level, string category, string message)
		{
			if (level == LogLevel.Debug && !DebugLogging)
			{
				return;
			}

			if (DisabledCategories.Contains(category.ToLower()))
			{
				return;
			}

			if (OnLog != null)
			{
				OnLog(level, "[" + category.ToUpper() + "] " + message);
			}
		}

		public static void DisableLogging(params string[] categories)
		{
			foreach (string s in categories)
			{
				DisabledCategories.Add(s.ToLower());
			}
		}

		public static void EnableLogging(params string[] categories)
		{
			foreach (string s in categories)
			{
				DisabledCategories.Remove(s.ToLower());
			}
		}
	}
}
