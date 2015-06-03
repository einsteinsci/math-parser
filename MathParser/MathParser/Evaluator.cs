using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.Tokens;
using MathParser.Lexing;
using MathParser.ParseTree;
using MathParser.Pratt;

namespace MathParser
{
	public class Evaluator
	{
		public static Evaluator Instance
		{ get; private set; }

		public string Input
		{ get; private set; }

		public TokenStream Lexed
		{ get; private set; }

		public NodeFactor ParseTree
		{ get; private set; }

		public IResultValue Result
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

		public static TokenStream Lex(string expression)
		{
			Instance.Input = expression;
			Instance.Lex();
			return Instance.Lexed;
		}

		public void Parse()
		{
			ParseTree = PrattParser.Parse(Lexed);
		}

		public static NodeFactor Parse(TokenStream stream)
		{
			Instance.Lexed = stream;
			Instance.Parse();
			return Instance.ParseTree;
		}

		public void Calculate()
		{
			Result = ParseTree.GetResult();
		}

		public static IResultValue Calculate(NodeFactor factor)
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

		public static IResultValue Evaluate(string expression)
		{
			Instance.Input = expression;
			Instance.Evaluate();
			return Instance.Result;
		}
	}
}
