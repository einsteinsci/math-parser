using MathParser.Lexing;
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

		public List<Lexeme> TokenStream
		{ get; set; }
	}
}
