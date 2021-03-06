﻿using MathParser.Functions;

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

		public NodeBase Parse(Parser parser, NodeBase left, Token token)
		{
			List<NodeBase> args = new List<NodeBase>();

			if (!parser.Match(TokenTypes.ParenthesisOut))
			{
				do 
				{
					args.Add(parser.Parse());
				} 
				while (parser.Match(TokenTypes.Comma));

				parser.Consume(TokenTypes.ParenthesisOut);
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
