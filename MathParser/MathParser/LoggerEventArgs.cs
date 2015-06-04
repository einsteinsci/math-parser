using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
	public class LoggerEventArgs : EventArgs
	{
		public string Message
		{ get; private set; }

		public LogLevel Level
		{ get; private set; }

		public string Category
		{ get; private set; }

		public string FullText
		{
			get
			{
				return "[" + Category.ToUpper() + "] " + Message;
			}
		}

		public LoggerEventArgs(LogLevel level, string category, string message)
		{
			Message = message;
			Level = level;
			Category = category;
		}
	}
}
