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

		public static bool DebugLogging
		{ get; set; }

		static Logger()
		{
			DebugLogging = true;
		}

		public static void Log(LogLevel level, string category, string message)
		{
			if (level == LogLevel.Debug && !DebugLogging)
			{
				return;
			}

			if (OnLog != null)
			{
				OnLog(level, "[" + category.ToUpper() + "] " + message);
			}
		}

		public static void Log(LogLevel level, string message)
		{
			Log(level, "misc", message);
		}

		public static void Log(string category, string message)
		{
			Log(LogLevel.Info, category, message);
		}

		public static void Log(string message)
		{
			Log(LogLevel.Info, message);
		}
	}
}
