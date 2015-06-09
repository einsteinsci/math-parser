
using MathParser.ParseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Lexing;
using MathParser.Types;

namespace MathParser.Parsing
{
	public class BooleanParselet : IPrefixParselet
	{
		public NodeBase Parse(Parser parser, Token token)
		{
			if (token.Lexeme.ToLower() == "true")
			{
				return new NodeLiteral(new ResultBoolean(true));
			}
			else if (token.Lexeme.ToLower() == "false")
			{
				return new NodeLiteral(new ResultBoolean(false));
			}
			else
			{
				throw new MismatchedRuleException("Not a valid boolean: " + token.Lexeme);
			}
		}
	}
}
