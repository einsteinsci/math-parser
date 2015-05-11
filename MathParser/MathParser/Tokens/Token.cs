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

		public static Token Comment					{ get { return TokenRegistry.Get("comment"); } }

		public static Token Comma					{ get { return TokenRegistry.Get("comma"); } }

		public static Token OperatorPlus			{ get { return TokenRegistry.Get("operatorPlus"); } }
		public static Token OperatorMinus			{ get { return TokenRegistry.Get("operatorMinus"); } }
		public static Token OperatorMultiply		{ get { return TokenRegistry.Get("operatorMultiply"); } }
		public static Token OperatorDivide			{ get { return TokenRegistry.Get("operatorDivide"); } }
		public static Token OperatorExponent		{ get { return TokenRegistry.Get("operatorExponent"); } }
		public static Token OperatorBitShiftLeft	{ get { return TokenRegistry.Get("operatorBitShiftLeft"); } }
		public static Token OperatorBitShiftRight	{ get { return TokenRegistry.Get("operatorBitShiftRight"); } }

		public static Token Number					{ get { return TokenRegistry.Get("number"); } }

		public static Token Unrecognized			{ get { return TokenRegistry.Get("unrecognized"); } }
	}
}
