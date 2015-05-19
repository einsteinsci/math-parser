using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.Tokens;
using MathParser.Lexing;
using MathParser.ParseTree;

namespace MathParser
{
	public class Evaluator
	{
		public static Evaluator Instance
		{ get; private set; }

		public string Input
		{ get; private set; }

		public LexStream Lexed
		{ get; private set; }

		public NodeFactor ParseTree
		{ get; private set; }

		public ResultValue Result
		{ get; private set; }

		static Evaluator()
		{
			Instance = new Evaluator();
		}

		#region parts
		public void Lex()
		{
			Lexed = Lexer.Lex(Input);
		}

		public static LexStream Lex(string expression)
		{
			Instance.Input = expression;
			Instance.Lex();
			return Instance.Lexed;
		}

		public void Parse()
		{
			ParseTree = Parser.Parse(Lexed);
		}

		public static NodeFactor Parse(LexStream stream)
		{
			Instance.Lexed = stream;
			Instance.Parse();
			return Instance.ParseTree;
		}

		public void Calculate()
		{
			Result = ParseTree.GetResult();
		}

		public static ResultValue Calculate(NodeFactor factor)
		{
			Instance.ParseTree = factor;
			Instance.Calculate();
			return Instance.Result;
		}
		#endregion

		public void Evaluate()
		{
			Lex();
			Parse();
			Calculate();
		}

		public static ResultValue Evaluate(string expression)
		{
			Instance.Input = expression;
			Instance.Evaluate();
			return Instance.Result;
		}
	}
}
