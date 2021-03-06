﻿
using MathParser.ParseTree;
using MathParser.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Parsing
{
	public class ListOrdinalParselet : IInfixParselet
	{
		public Precedence PrecedenceLevel
		{ get { return Precedence.PRIMARY; } }

		public NodeBase Parse(Parser parser, NodeBase left, Token token)
		{
			NodeBase ordinal = parser.Parse();

			parser.Consume(TokenTypes.BracketOut);

			return new NodeListOrdinal(left, ordinal);
		}
	}
}
