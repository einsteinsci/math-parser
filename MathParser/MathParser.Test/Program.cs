using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser;
using MathParser.Tokens;
using MathParser.Lexing;
using MathParser.ParseTree;
using MathParser.Pratt;

namespace MathParser.Test
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Logger.OnLog += Log;
			//Logger.DisableLogging(Logger.REGISTRY);

			string input = "";
			Console.Write("Input> ");
			input = Console.ReadLine();

			VariableRegistry.Global.Create("a", new ResultNumberReal(0));
			VariableRegistry.Global.Create("b", new ResultNumberReal(0));
			VariableRegistry.Global.Create("c", new ResultNumberReal(0));
			VariableRegistry.Global.Create("d", new ResultNumberReal(0));
			VariableRegistry.Global.Create("e", new ResultNumberReal(0));

			TokenStream stream = Evaluator.Lex(input);
			NodeFactor root = Evaluator.Parse(stream);
			IResultValue res = Evaluator.Calculate(root);

			//IResultValue res = Evaluator.Evaluate(input);
			
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\nEvaluated: ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write(input); 
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write(" = " + res.ToDisplay());

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
