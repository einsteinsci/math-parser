using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser;
using MathParser.Tokens;
using MathParser.Lexing;
using MathParser.ParseTree;

namespace MathParser.Test
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Logger.OnLog += Log;
			Logger.DisableLogging("register");

			string input = "";
			Console.Write("Input> ");
			//input = Console.ReadLine();
			input = "5 + -3";

			// This is where evaluation occurs
			ResultValue res = Evaluator.Evaluate(input);
			
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Evaluated: " + input + " = " + res.ToString());

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
