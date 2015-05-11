using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser;
using MathParser.Tokens;

namespace MathParser.Test
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.ForegroundColor = ConsoleColor.White;
			Logger.OnLog += Log;
			Logger.DebugLogging = true;

			string input = "3 << (5 >> 2)";

			// TODO: Figure out why tokens aren't recognized this way.
			Token t = Token.ParenthesisIn;

			Console.WriteLine("Input> " + input);
			var res = Lexing.Lexer.Lex(input);

			Console.ReadKey(true);
		}

		static void Log(LogLevel level, string message)
		{
			switch (level)
			{
			case LogLevel.Debug:
				Console.ForegroundColor = ConsoleColor.Gray;
				break;
			case LogLevel.Info:
				Console.ForegroundColor = ConsoleColor.White;
				break;
			case LogLevel.Warning:
				Console.ForegroundColor = ConsoleColor.Yellow;
				break;
			case LogLevel.Error:
				Console.ForegroundColor = ConsoleColor.Red;
				break;
			case LogLevel.Fatal:
				Console.ForegroundColor = ConsoleColor.DarkRed;
				break;
			default:
				Console.ForegroundColor = ConsoleColor.Magenta;
				break;
			}

			Console.WriteLine("" + message);

			Console.ForegroundColor = ConsoleColor.White;
		}
	}
}
