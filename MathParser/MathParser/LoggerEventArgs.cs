using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
	/// <summary>
	/// Contains event arguments for logging
	/// </summary>
	public class LoggerEventArgs : EventArgs
	{
		/// <summary>
		/// Message sent to logger
		/// </summary>
		public string Message
		{ get; private set; }

		/// <summary>
		/// Level of message
		/// </summary>
		public LogLevel Level
		{ get; private set; }

		/// <summary>
		/// Category of message
		/// </summary>
		public string Category
		{ get; private set; }

		/// <summary>
		/// Full compiled text of message, for convenience
		/// </summary>
		public string FullText
		{
			get
			{
				return "[" + Category.ToUpper() + "] " + Message;
			}
		}

		/// <summary>
		/// Instantiates a new LoggerEventArgs
		/// </summary>
		/// <param name="level">Level of message</param>
		/// <param name="category">Category of message</param>
		/// <param name="message">Message</param>
		public LoggerEventArgs(LogLevel level, string category, string message)
		{
			Message = message;
			Level = level;
			Category = category;
		}

		/// <summary>
		/// Converts the object to a string
		/// </summary>
		/// <returns>this.FullText</returns>
		public override string ToString()
		{
			return FullText;
		}
	}
}
