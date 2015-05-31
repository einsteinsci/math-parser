using MathParser.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Tokens;
using MathParser.Rules;

namespace MathParser.ConcreteTree
{
	public sealed class ParserLL
	{
		public TokenStream Stream
		{ get; private set; }

		public INonTerminal Root
		{ get; private set; }

		// "climbs" down the parse tree to add nodes
		public INonTerminal CurrentNode
		{ get; private set; }

		// Recursive Descent
		// YES, THIS IS LITTERED WITH ERRORS. ALL THESE NODE CLASSES WILL BE REDEFINED.
		public void Parse()
		{
			Root = new CNodeFactor();
			CurrentNode = Root;
			Root.Expect(CurrentNode, Stream);
		}

		private bool Factor()
		{
			bool assign = Assign();
			if (assign)
			{
				return true;
			}
			else
			{

			}

			bool postfix = Postfix();
			return postfix;
		}

		private bool Assign()
		{
			Token next = Stream.Peek();
			if (!Accept(TokenClass.Identifier))
			{
				return false;
			}
			
			//CNodeAssignment leaf = new CNodeAssignment();
			//leaf.Variable = next.Lexed;
			//CurrentNode.ChildNode = leaf;

			Expect(TokenClass.OperatorAssignment);
			if (!Factor())
			{
				throw new MismatchedRuleException(
					"Expected factor on right side of assignment.");
			}

			return true;
		}

		private bool Postfix()
		{
			return true;
		}

		private bool Accept(TokenClass tClass)
		{
			Token buf = Stream.Next();
			return buf.Class == tClass;
		}

		private void Expect(TokenClass tokenClass)
		{
			if (!Accept(tokenClass))
			{
				throw new MismatchedRuleException(
					"Expected token " + tokenClass.ToString());
			}
		}

		private void Debug(string message)
		{
			Logger.Log(LogLevel.Debug, Logger.PARSER, message);
		}
	}
}
