using MathParser.Lexing;
using MathParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	public sealed class Parser
	{
		public static readonly Parser Instance = new Parser();

		public LexStream Input
		{ get; private set; }

		public Factor<double> ParseTree
		{ get; private set; }

		// Shunting-yard algorithm (http://en.wikipedia.org/wiki/Shunting-yard_algorithm)
		public void Parse()
		{
			Stack<Lexeme> operatorStack = new Stack<Lexeme>();
			Queue<Lexeme> outputQueue = new Queue<Lexeme>();

			#region sequencing
			for (int index = 0; index < Input.Count; index++)
			{
				Lexeme lex = Input[index];

				switch (lex.Type)
				{
				case TokenType.Operator:
					OperatorShuffle(operatorStack, outputQueue, lex);
					continue;
				case TokenType.Literal:
					outputQueue.Enqueue(lex);
					continue;
				case TokenType.Name:
					if (IsFunctionValid(lex.Lexed)) // its a function
					{
						operatorStack.Push(lex);
						continue;
					}
					else
					{
						Logger.Log(LogLevel.Error, "parser", 
							"Custom identifiers are not supported yet.");
						continue;
					}
					break;
				case TokenType.Delimiter:
					#region Delimiter
					try
					{
						while (operatorStack.Peek().Token != Token.ParenthesisIn)
						{
							Lexeme l = operatorStack.Pop();
							outputQueue.Enqueue(l);
						}
						continue;
					}
					catch (InvalidOperationException)
					{
						Logger.Log(LogLevel.Fatal, "parsing", "Impossible Token Type.");
						throw new Exception("Mismatched Parentheses.");
					}
					#endregion
				case TokenType.Encloser:
					#region Encloser
					if (lex.Token == Token.ParenthesisIn)
					{
						operatorStack.Push(lex);
						continue;
					}
					else if (lex.Token == Token.ParenthesisOut)
					{
						FinishParentheses(operatorStack, outputQueue);
					}
					break;
					#endregion
				case TokenType.Ignored:
					// NEXT!
					continue;
				default:
					Logger.Log(LogLevel.Fatal, "parsing", "Impossible Token Type.");
					throw new Exception("Impossible Token Type.");
				}
			}

			while (operatorStack.Count > 0)
			{
				Lexeme l = operatorStack.Pop();
				if (l.Token == Token.ParenthesisIn)
				{
					Logger.Log(LogLevel.Error, "parsing", "Mismatched parentheses.");
				}

				outputQueue.Enqueue(l);
			}
			#endregion

			string seq = "Parsed:\n\t";
			foreach (Lexeme l in outputQueue)
			{
				seq += l.ToString() + "\n\t";
			}
			Logger.Log(LogLevel.Debug, "parser", seq);

			Stack<Factor<double>> arguments = new Stack<Factor<double>>();
			
			#region parsing
			while (outputQueue.Count > 0)
			{
				Lexeme lex = outputQueue.Dequeue();

				if (lex.Type == TokenType.Literal)
				{
					string lit = lex.Lexed;
					double d = double.Parse(lit);
					arguments.Push(new Literal<double>(d));
					continue;
				}
				if (lex.Type == TokenType.Operator)
				{
					TokenOperator op = lex.Token as TokenOperator;
					if (arguments.Count < op.ArgumentCount)
					{
						Logger.Log(LogLevel.Error, "parsing", "Too many arguments for token " + op.ToString());
					}

					List<Factor<double>> argsTaken = new List<Factor<double>>();
					for (int i = 0; i < op.ArgumentCount; i++)
					{
						Factor<double> arg = arguments.Pop();
						argsTaken.Add(arg);
					}

					Factor<double> branch = MakeOperator(argsTaken, op);
					arguments.Push(branch);
				}
				if (lex.Type == TokenType.Literal) // function
				{
					throw new NotImplementedException();
				}
			}
			#endregion
		}

		public static Factor<double> MakeOperator(List<Factor<double>> arguments, TokenOperator op)
		{
			switch (op.Operator)
			{
			case "+":
				return new OperatorPlus(arguments[0], arguments[1]);
			case "-":
				return new OperatorMinus(arguments[0], arguments[1]);
			case "*":
				return new OperatorMultiply(arguments[0], arguments[1]);
			case "/":
				return new OperatorDivide(arguments[0], arguments[1]);
			case "^":
				return new OperatorExponent(arguments[0], arguments[1]);
			case "%":
				return new OperatorModulus(arguments[0], arguments[1]);
			default:
				throw new ArgumentException("Unrecognized operator");
			}
		}

		public static void FinishParentheses(Stack<Lexeme> operatorStack, 
			Queue<Lexeme> outputQueue)
		{
			try
			{
				while (operatorStack.Peek().Token != Token.ParenthesisIn)
				{
					Lexeme l = operatorStack.Pop();
					outputQueue.Enqueue(l);
				}
			}
			catch (InvalidOperationException)
			{
				Logger.Log(LogLevel.Fatal, "parsing", "Mismatched Parentheses Found.");
				throw new Exception("Mismatched Parentheses.");
			}
			Lexeme parin = operatorStack.Pop();
			if (operatorStack.Count > 0)
			{
				if (operatorStack.Peek().Type == TokenType.Name) // function
				{
					Lexeme func = operatorStack.Pop();
					outputQueue.Enqueue(func);
				}
			}
		}

		public static void OperatorShuffle(Stack<Lexeme> operatorStack, 
			Queue<Lexeme> outputQueue, Lexeme current)
		{
			TokenOperator o1 = current.Token as TokenOperator;
			while (true)
			{
				if (operatorStack.Count == 0)
				{
					break;
				}
				Lexeme l2 = operatorStack.Peek();
				if (l2.Type != TokenType.Operator)
				{
					break;
				}

				TokenOperator o2 = l2.Token as TokenOperator;

				bool leftWorks = o1.Precedence <= o2.Precedence;
				bool rightWorks = o1.Precedence < o2.Precedence;
				bool leftAssociative = !o1.IsRightAssociative;
				
				if (!((leftAssociative && leftWorks) || (!leftAssociative && rightWorks)))
				{
					break;
				}

				l2 = operatorStack.Pop();
				outputQueue.Enqueue(l2);
			}

			operatorStack.Push(current);
		}

		public static bool IsFunctionValid(string func)
		{
			foreach (FunctionInfo f in MathFunctions.AllFunctions)
			{
				if (f.Name == func)
				{
					return true;
				}
			}

			return false;
		}

		public static Factor<double> Parse(LexStream stream)
		{
			Instance.Input = stream;

			Instance.Parse();

			return Instance.ParseTree;
		}
	}
}
