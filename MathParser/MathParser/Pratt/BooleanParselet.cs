﻿
using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Tokens;
using MathParser.Types;

namespace MathParser.Pratt
{
	public class BooleanParselet : IPrefixParselet
	{
		public NodeFactor Parse(PrattParser parser, Token token)
		{
			if (token.Lexed.ToLower() == "true")
			{
				return new NodeLiteral(new ResultBoolean(true));
			}
			else if (token.Lexed.ToLower() == "false")
			{
				return new NodeLiteral(new ResultBoolean(false));
			}
			else
			{
				throw new MismatchedRuleException("Not a valid boolean: " + token.Lexed);
			}
		}
	}
}
