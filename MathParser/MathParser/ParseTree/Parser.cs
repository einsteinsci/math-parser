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

		// Shunting-yard algorithm
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
					#region Operator
					while (operatorStack.Count > 0 && operatorStack.Peek().Type == TokenType.Operator)
					{
						TokenOperator o2 = operatorStack.Peek().Token as TokenOperator;
						TokenOperator o1 = lex.Token as TokenOperator;

						if ((!o1.IsRightAssociative && o1.Precedence <= o2.Precedence) ||
							(o1.IsRightAssociative && o1.Precedence < o2.Precedence))
						{
							Lexeme op = operatorStack.Pop();
							outputQueue.Enqueue(op);
						}
						operatorStack.Push(lex);
					}
					continue;
					#endregion
				case TokenType.Literal:
					outputQueue.Enqueue(lex);
					continue;
				case TokenType.Name:
					if (IsFunctionValid(lex.Lexed)) // its a function
					{
						operatorStack.Push(lex);
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
			#endregion

			string seq = "";
			//foreach (Lexeme l )

			List<Lexeme> arguments = new List<Lexeme>();
			
			#region parsing
			while (outputQueue.Count > 0)
			{
				Lexeme lex = outputQueue.Dequeue();

				if (lex.Type == TokenType.Literal)
				{
					arguments.Add(lex);
				}
			}
			#endregion
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
