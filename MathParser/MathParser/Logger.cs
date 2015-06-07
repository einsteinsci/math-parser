using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
	/// <summary>
	/// Level of importance of message
	/// </summary>
	public enum LogLevel
	{
		/// <summary>
		/// Debugging info, hidden by default
		/// </summary>
		Debug = -1,
		/// <summary>
		/// Regular information
		/// </summary>
		Info = 0,
		/// <summary>
		/// An unusual occurrance has been encountered
		/// </summary>
		Warning,
		/// <summary>
		/// An error has been encountered, but can be easily dealt with
		/// </summary>
		Error,
		/// <summary>
		/// A fatal error has been encountered, and likely cannot be handled.
		/// </summary>
		Fatal
	}

	/// <summary>
	/// Provides options for logging within the parser
	/// </summary>
	public static class Logger
	{
		/// <summary>
		/// Delegate for handling any logging
		/// </summary>
		/// <param name="sender">
		///   Object sending the log message, 
		///   really just here for the design pattern.
		/// </param>
		/// <param name="e">Arguments of logging</param>
		public delegate void LogEventHandler(object sender, LoggerEventArgs e);

		/// <summary>
		/// Subscribe to this with your preferred method of logging
		/// </summary>
		public static event LogEventHandler OnLog;

		/// <summary>
		/// The message involves the tokenizer
		/// </summary>
		public const string TOKENIZER = "tokenize";
		/// <summary>
		/// The message involves the parser
		/// </summary>
		public const string PARSER = "parse";
		/// <summary>
		/// The message involves the evaluation
		/// </summary>
		public const string EVALUATOR = "evaluate";
		/// <summary>
		/// The message involves the registry of tokens, parselets, etc.
		/// </summary>
		public const string REGISTRY = "register";

		/// <summary>
		/// Set to true to show debug messages
		/// </summary>
		public static bool DebugLogging
		{ get; set; }

		/// <summary>
		/// Set of all categories disabled. Use DisableLogging() and 
		/// EnableLogging() to disable and enable logging for categories.
		/// </summary>
		public static ISet<string> DisabledCategories
		{ get; private set; }

		static Logger()
		{
			DebugLogging = false;
			DisabledCategories = new SortedSet<string>();
		}

		/// <summary>
		/// Logs a message
		/// </summary>
		/// <param name="level">Level of message</param>
		/// <param name="category">Category of message</param>
		/// <param name="message">Message sent</param>
		/// <param name="sender">Object that is sending the message, mostly useless</param>
		public static void Log(LogLevel level, string category, string message, object sender = null)
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
				OnLog(sender, new LoggerEventArgs(level, category, message));
			}
		}

		/// <summary>
		/// Disables logging for categories
		/// </summary>
		/// <param name="categories">Categories to disable</param>
		public static void DisableLogging(params string[] categories)
		{
			foreach (string s in categories)
			{
				DisabledCategories.Add(s.ToLower());
			}
		}

		/// <summary>
		/// Enables logging for disabled categories
		/// </summary>
		/// <param name="categories"></param>
		public static void EnableLogging(params string[] categories)
		{
			foreach (string s in categories)
			{
				DisabledCategories.Remove(s.ToLower());
			}
		}
	}
}
