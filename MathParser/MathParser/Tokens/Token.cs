using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace MathParser.Tokens
{
	public abstract class Token
	{
		public abstract bool SingleChar
		{ get; }

		public abstract bool Matches(string lexeme);

		public virtual bool IsOperator
		{ get { return false; } }

		public virtual List<Token> CustomRegistry
		{ get { return null; } }

		public static Token Comment { get { return TokenRegistry.Get("comment"); } }
		public static Token OperatorPlus { get { return TokenRegistry.Get("operatorPlus"); } }
		public static Token Number { get { return TokenRegistry.Get("number"); } }

		public static Token Unrecognized { get { return TokenRegistry.Get("unrecognized"); } }
	}
}
