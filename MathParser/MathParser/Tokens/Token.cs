using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace MathParser.Tokens
{
	public enum TokenType
	{
		Operator,
		Literal,
		Name,
		Delimiter,
		Encloser,
		Ignored
	}

	public abstract class Token
	{
		public abstract bool Matches(string lexeme);

		public abstract TokenType Type
		{ get; }

		public abstract int LexerPriority
		{ get; }

		public virtual Dictionary<string, Token> CustomRegistry
		{ get { return null; } }

		public static Token Comment					{ get { return TokenRegistry.Get("comment"); } }

		public static Token Comma					{ get { return TokenRegistry.Get("comma"); } }

		public static Token ParenthesisIn			{ get { return TokenRegistry.Get("parenthesisOpen"); } }
		public static Token ParenthesisOut			{ get { return TokenRegistry.Get("parenthesisClose"); } }
		public static Token BracketIn				{ get { return TokenRegistry.Get("bracketOpen"); } }
		public static Token BracketOut				{ get { return TokenRegistry.Get("bracketClose"); } }
		public static Token BraceIn					{ get { return TokenRegistry.Get("braceOpen"); } }
		public static Token BraceOut				{ get { return TokenRegistry.Get("braceClose"); } }

		public static Token OperatorPlus			{ get { return TokenRegistry.Get("operatorPlus"); } }
		public static Token OperatorMinus			{ get { return TokenRegistry.Get("operatorMinus"); } }
		public static Token OperatorMultiply		{ get { return TokenRegistry.Get("operatorMultiply"); } }
		public static Token OperatorDivide			{ get { return TokenRegistry.Get("operatorDivide"); } }
		public static Token OperatorExponent		{ get { return TokenRegistry.Get("operatorExponent"); } }
		public static Token OperatorModulus			{ get { return TokenRegistry.Get("operatorModulus"); } }
		public static Token OperatorBitShiftLeft	{ get { return TokenRegistry.Get("operatorBitShiftLeft"); } }
		public static Token OperatorBitShiftRight	{ get { return TokenRegistry.Get("operatorBitShiftRight"); } }

		public static Token OperatorNegative		{ get { return TokenRegistry.Get("operatorNegative"); } }
		public static Token OperatorFactorial		{ get { return TokenRegistry.Get("operatorFactorial"); } }
		public static Token OperatorNot				{ get { return TokenRegistry.Get("operatorNot"); } }

		public static Token OperatorConditionalAnd	{ get { return TokenRegistry.Get("operatorConditionalAnd"); } }
		public static Token OperatorConditionalOr	{ get { return TokenRegistry.Get("operatorConditionalOr"); } }

		public static Token OperatorEqual			{ get { return TokenRegistry.Get("operatorEqual"); } }
		public static Token OperatorNotEqual		{ get { return TokenRegistry.Get("operatorNotEqual"); } }
		public static Token OperatorGreaterThan		{ get { return TokenRegistry.Get("operatorGreaterThan"); } }
		public static Token OperatorLessThan		{ get { return TokenRegistry.Get("operatorLessThan"); } }
		public static Token OperatorGreaterThanOrEqual		{ get { return TokenRegistry.Get("operatorGreaterThanOrEqual"); } }
		public static Token OperatorLessThanOrEqual			{ get { return TokenRegistry.Get("operatorLessThanOrEqual"); } }

		public static Token OperatorAssignment		{ get { return TokenRegistry.Get("operatorAssigment"); } }

		public static Token Number					{ get { return TokenRegistry.Get("number"); } }
		public static Token String					{ get { return TokenRegistry.Get("string"); } }
		public static Token Boolean					{ get { return TokenRegistry.Get("boolean"); } }

		public static Token Unrecognized			{ get { return TokenRegistry.Get("unrecognized"); } }
	}
}
