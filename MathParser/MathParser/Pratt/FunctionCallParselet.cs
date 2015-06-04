using MathParser.Functions;
using MathParser.Lexing;
using MathParser.ParseTree;
using MathParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Pratt
{
	public class FunctionCallParselet : IInfixParselet
	{
		public Precedence PrecedenceLevel
		{ get { return Precedence.PRIMARY; } }

		public NodeFactor Parse(PrattParser parser, NodeFactor left, Token token)
		{
			List<NodeFactor> args = new List<NodeFactor>();

			if (!parser.Match(TokenClass.ParenthesisOut))
			{
				do 
				{
					args.Add(parser.Parse());
				} 
				while (parser.Match(TokenClass.Comma));

				parser.Consume(TokenClass.ParenthesisOut);
			}

			NodeIdentifier name = left as NodeIdentifier;

			return new NodeFunction(MathFunctions.GetFunction(name.IdentifierName), args.ToArray());
		}
	}
}
