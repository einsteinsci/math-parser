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

		public TokenStream Input
		{ get; private set; }

		public NodeFactor ParseTree
		{ get; private set; }

		// Shunting-yard algorithm (http://en.wikipedia.org/wiki/Shunting-yard_algorithm)
		public void Parse()
		{
			Stack<Lexeme> operatorStack = new Stack<Lexeme>();
			Queue<Lexeme> outputQueue = new Queue<Lexeme>();

			bool isInList = false;
			int listSize = 0;

			#region sequencing
			for (int index = 0; index < Input.Count; index++)
			{
				Lexeme lex = Input[index];

				switch (lex.Type)
				{
				case TokenType.Operator:
					if (isInList && IsTopLevelBrace(operatorStack) && listSize == 0)
					{
						listSize++;
					}

					Logger.Log(LogLevel.Debug, Logger.SEQUENCER,
						"Found operator: " + lex.ToString());
					OperatorShuffle(operatorStack, outputQueue, lex);
					continue;
				case TokenType.Literal:
					if (isInList && IsTopLevelBrace(operatorStack) && listSize == 0)
					{
						listSize++;
					}

					Logger.Log(LogLevel.Debug, Logger.SEQUENCER,
						"Moving to output queue: " + lex.ToString());
					outputQueue.Enqueue(lex);
					continue;
				case TokenType.Name:
					if (isInList && IsTopLevelBrace(operatorStack) && listSize == 0)
					{
						listSize++;
					}

					if (IsFunctionValid(lex.Lexed)) // its a function
					{
						Logger.Log(LogLevel.Debug, Logger.SEQUENCER,
							"Pushing to operator stack: " + lex.ToString());
						operatorStack.Push(lex);
						continue;
					}
					else
					{
						Logger.Log(LogLevel.Debug, Logger.SEQUENCER, 
							"Moving to output queue: " + lex.ToString());
						outputQueue.Enqueue(lex);
						continue;
					}
				case TokenType.Delimiter:
					#region Delimiter
					if (isInList && IsTopLevelBrace(operatorStack))
					{
						listSize++;
						continue;
					}

					try
					{
						while (operatorStack.Peek().Token != TokenClass.ParenthesisIn)
						{
							Lexeme l = operatorStack.Pop();
							Logger.Log(LogLevel.Debug, Logger.SEQUENCER,
								"Popping operator to output queue: " + l.ToString());
							outputQueue.Enqueue(l);
						}
						continue;
					}
					catch (InvalidOperationException)
					{
						Logger.Log(LogLevel.Fatal, Logger.SEQUENCER, "Impossible Token Type.");
						throw new Exception("Mismatched Parentheses.");
					}
					#endregion
				case TokenType.Encloser:
					#region Encloser
					if (lex.Token == TokenClass.ParenthesisIn)
					{
						Logger.Log(LogLevel.Debug, Logger.SEQUENCER,
							"Moving entry parenthesis to operator stack.");
						operatorStack.Push(lex);
						continue;
					}
					else if (lex.Token == TokenClass.ParenthesisOut)
					{
						Logger.Log(LogLevel.Debug, Logger.SEQUENCER,
							"Found exit parenthesis. Finishing parenthesis pair.");
						FinishParentheses(operatorStack, outputQueue);
						continue;
					}
					else if (lex.Token == TokenClass.BraceIn) // list
					{
						Logger.Log(LogLevel.Debug, Logger.SEQUENCER,
							"Found entry brace. Entering list mode.");
						isInList = true;
						continue;
					}
					else if (lex.Token == TokenClass.BraceOut) // end list
					{
						Logger.Log(LogLevel.Debug, Logger.SEQUENCER,
							"Found exit brace. Finishing brace group.");
						isInList = false;
						listSize = 0;
						FinishBraces(operatorStack, outputQueue, listSize);
						// HERE
					}
					break;
					#endregion
				case TokenType.Ignored:
					Logger.Log(LogLevel.Debug, Logger.SEQUENCER,
						"Found ignored token. Discarding " + lex.ToString());
					// NEXT!
					continue;
				default:
					Logger.Log(LogLevel.Fatal, Logger.SEQUENCER, "Impossible Token Type.");
					throw new Exception("Impossible Token Type.");
				}
			}

			while (operatorStack.Count > 0)
			{
				Lexeme l = operatorStack.Pop();
				Logger.Log(LogLevel.Debug, Logger.SEQUENCER,
					"Popping operator to output queue: " + l.ToString());
				if (l.Token == TokenClass.ParenthesisIn)
				{
					Logger.Log(LogLevel.Error, Logger.SEQUENCER, "Mismatched parentheses.");
				}

				outputQueue.Enqueue(l);
			}
			#endregion

			string seq = "Parsed:\n\t";
			foreach (Lexeme l in outputQueue)
			{
				seq += l.ToString() + "\n\t";
			}
			seq = seq.Trim();
			Logger.Log(LogLevel.Debug, Logger.SEQUENCER, seq);

			Stack<NodeFactor> arguments = new Stack<NodeFactor>();
			
			#region parsing
			while (outputQueue.Count > 0)
			{
				Lexeme lex = outputQueue.Dequeue();

				if (lex.Type == TokenType.Literal)
				{
					string lit = lex.Lexed;
					TokenClassLiteral toklit = lex.Token as TokenClassLiteral;
					Logger.Log(LogLevel.Debug, Logger.PARSER,
						"Creating literal node from value: " + lex.ToString());
					arguments.Push(toklit.MakeNode(lit));
					continue;
				}
				if (lex.Type == TokenType.Operator)
				{
					TokenClassOperator op = lex.Token as TokenClassOperator;
					if (arguments.Count < op.ArgumentCount)
					{
						Logger.Log(LogLevel.Error, Logger.PARSER, "Too many arguments for token " + op.ToString());
					}

					List<NodeFactor> argsTaken = new List<NodeFactor>();
					for (int i = 0; i < op.ArgumentCount; i++)
					{
						NodeFactor arg = arguments.Pop();
						argsTaken.Add(arg);
					}
					argsTaken.Reverse();

					Logger.Log(LogLevel.Debug, Logger.PARSER,
						"Creating operator node from token: " + lex.ToString());
					NodeFactor branch = MakeOperator(argsTaken, op);
					arguments.Push(branch);
				}
				if (lex.Type == TokenType.Name) // function
				{
					TokenClassIdentifier id = lex.Token as TokenClassIdentifier;
					string name = lex.Lexed;

					if (MathFunctions.GetFunction(name) == null)
					{
						Logger.Log(LogLevel.Debug, Logger.PARSER,
							"Creating identifier node from variable: " + name);
						arguments.Push(new NodeIdentifier(name));
					}
					else
					{
						FunctionInfo fInfo = MathFunctions.GetFunction(name);
						//if (fInfo == null)
						//{
						//	Logger.Log(LogLevel.Error, Logger.PARSER, "No such function: " + name + "(...)");
						//	throw new MissingMethodException("No such function: " + name + "(...)");
						//}

						List<NodeFactor> argsTaken = new List<NodeFactor>();
						for (int i = 0; i < fInfo.ArgumentCount; i++)
						{
							NodeFactor arg = arguments.Pop();
							argsTaken.Add(arg);
						}
						argsTaken.Reverse();

						Logger.Log(LogLevel.Debug, Logger.PARSER,
							"Creating function node from token: " + lex.ToString());
						NodeFactor branch = new NodeFunction(fInfo, argsTaken.ToArray());
						arguments.Push(branch);
					}
				}
			}

			NodeFactor root = arguments.FirstOrDefault();
			if (root == null)
			{
				throw new Exception("This should never happen.");
			}

			Logger.Log(LogLevel.Debug, Logger.PARSER, "Stringified form of parse tree: " + root.ToString());

			ParseTree = root;
			#endregion
		}

		public static NodeFactor MakeOperator(List<NodeFactor> arguments, TokenClassOperator op)
		{
			return op.MakeFactor(arguments.ToArray());
		}

		public static void FinishParentheses(Stack<Lexeme> operatorStack, 
			Queue<Lexeme> outputQueue)
		{
			try
			{
				while (operatorStack.Peek().Token != TokenClass.ParenthesisIn)
				{
					Lexeme l = operatorStack.Pop();
					Logger.Log(LogLevel.Debug, Logger.SEQUENCER,
						"Popping operator into output queue: " + l.ToString());
					outputQueue.Enqueue(l);
				}
			}
			catch (InvalidOperationException)
			{
				Logger.Log(LogLevel.Fatal, Logger.SEQUENCER, "Mismatched Parentheses Found.");
				throw new Exception("Mismatched Parentheses.");
			}
			Lexeme parin = operatorStack.Pop();
			if (operatorStack.Count > 0)
			{
				if (operatorStack.Peek().Type == TokenType.Name) // function
				{
					Lexeme func = operatorStack.Pop();
					Logger.Log(LogLevel.Debug, Logger.SEQUENCER,
						"Popping function name into output queue: " + func.ToString());
					outputQueue.Enqueue(func);
				}
			}
		}

		public static void FinishBraces(Stack<Lexeme> operatorStack,
			Queue<Lexeme> outputQueue, int listSize)
		{
			try
			{
				while (operatorStack.Peek().Token != TokenClass.BraceIn)
				{
					Lexeme l = operatorStack.Pop();
				}
			}
			catch
			{

			}
		}

		public static void OperatorShuffle(Stack<Lexeme> operatorStack, 
			Queue<Lexeme> outputQueue, Lexeme current)
		{
			TokenClassOperator o1 = current.Token as TokenClassOperator;
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

				TokenClassOperator o2 = l2.Token as TokenClassOperator;

				bool leftWorks = o1.Precedence <= o2.Precedence;
				bool rightWorks = o1.Precedence < o2.Precedence;
				bool leftAssociative = !o1.IsRightAssociative;
				
				if (!((leftAssociative && leftWorks) || (!leftAssociative && rightWorks)))
				{
					Logger.Log(LogLevel.Debug, Logger.SEQUENCER,
						"Done popping higher-precedence operators to output queue.");
					break;
				}

				l2 = operatorStack.Pop();
				Logger.Log(LogLevel.Debug, Logger.SEQUENCER,
					"Popping higher-precedence operator to output queue: " + l2.ToString());
				outputQueue.Enqueue(l2);
			}

			Logger.Log(LogLevel.Debug, Logger.SEQUENCER,
				"Pushing low-precedence operator onto stack: " + current.ToString());
			operatorStack.Push(current);
		}

		public static bool IsTopLevelBrace(Stack<Lexeme> operatorStack)
		{
			foreach (Lexeme lex in operatorStack)
			{
				if (lex.Token is TokenClassParenthesis)
				{
					return false;
				}
				else if (lex.Token is TokenClassBrace)
				{
					return true;
				}
			}

			return false;
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

		public static NodeFactor Parse(TokenStream stream)
		{
			Instance.Input = stream;

			Instance.Parse();

			return Instance.ParseTree;
		}
	}
}
