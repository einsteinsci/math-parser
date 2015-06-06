using MathParser.Functions;

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

			return new NodeFunction(Functions.Functions.GetFunction(name.IdentifierName), args.ToArray());
		}
	}
}
