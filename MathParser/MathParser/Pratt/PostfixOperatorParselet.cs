﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.ParseTree;
using MathParser.Tokens;

namespace MathParser.Pratt
{
	public class PostfixOperatorParselet : IInfixParselet
	{
		public Precedence PrecedenceLevel
		{ get; private set; }

		public PostfixOperatorParselet(Precedence precedence)
		{
			PrecedenceLevel = precedence;
		}

		public NodeFactor Parse(PrattParser parser, NodeFactor left, Token token)
		{
			return UnaryPostfixRegistry.MakeNode(token.Class, left);
		}
	}
}
