using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser;
using MathParser.Lexing;
using MathParser.Types;

using MathParser.ParseTree;
using System.Reflection;

namespace MathParser.Test
{
	class Program
	{
		static void Main(string[] args)
		{
			Logger.OnLog += Log;
			Logger.DisableLogging(Logger.REGISTRY);

			//Extensibility.LoadedExtensions.Add(Assembly.GetExecutingAssembly());

			Evaluator.Initialize();

			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("Input> ");
			string input = Console.ReadLine();
			
			IResultValue res = Evaluator.Evaluate(input);
			
			Console.WriteLine("Evaluated: " + input);
			Console.WriteLine("Result: " + res.ToDisplay());

			Console.ReadKey(true);
		}

		static void Log(object sender, LoggerEventArgs e)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("[" + e.Category.ToUpper() + "] ");

			switch (e.Level)
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

			Console.WriteLine(e.Message);

			Console.ForegroundColor = ConsoleColor.White;
		}
	}
}
