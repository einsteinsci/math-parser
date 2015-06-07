using MathParser.Functions;

using MathParser.ParseTree;
using MathParser.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MathParser.Parsing
{
	public class FunctionCallParselet : IInfixParselet
	{
		public Precedence PrecedenceLevel
		{ get { return Precedence.PRIMARY; } }

		public NodeFactor Parse(PrattParser parser, NodeFactor left, Token token)
		{
			List<NodeFactor> args = new List<NodeFactor>();

			if (!parser.Match(TokenType.ParenthesisOut))
			{
				do 
				{
					args.Add(parser.Parse());
				} 
				while (parser.Match(TokenType.Comma));

				parser.Consume(TokenType.ParenthesisOut);
			}

			NodeIdentifier name = left as NodeIdentifier;

			FunctionInfo info = FunctionRegistry.GetFunction(name.IdentifierName);

			if (info == null)
			{
				throw new MismatchedRuleException("Function " + name + " not found.");
			}

			return new NodeFunction(info, args.ToArray());
		}
	}
}
