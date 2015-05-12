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

			for (int index = 0; index < Input.Count; index++)
			{
				Lexeme lex = Input[index];

				switch (lex.Type)
				{
				case TokenType.Operator:
					break;
				case TokenType.Literal:
					break;
				case TokenType.Name:

					break;
				case TokenType.Delimiter:
					break;
				case TokenType.Encloser:
					break;
				case TokenType.Ignored:
					// NEXT!
					continue;
				default:
					throw new Exception("Impossible Token Type.");
				}
			}
		}

		public static Factor<double> Parse(LexStream stream)
		{
			Instance.Input = stream;

			Instance.Parse();

			return Instance.ParseTree;
		}
	}
}
