using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace MathParser.Tokens
{
	public abstract class TokenType
	{
		public abstract bool Matches(string lexeme);
		
		public abstract int LexerPriority
		{ get; }

		public virtual bool IgnoreInTree
		{ get { return false; } }

		public virtual Dictionary<string, TokenType> CustomRegistry
		{ get { return null; } }

		#region tokens
		public static TokenType Comment				{ get { return TokenTypeRegistry.Get("comment"); } }

		public static TokenType Comma					{ get { return TokenTypeRegistry.Get("comma"); } }

		public static TokenType ParenthesisIn			{ get { return TokenTypeRegistry.Get("parenthesisOpen"); } }
		public static TokenType ParenthesisOut			{ get { return TokenTypeRegistry.Get("parenthesisClose"); } }
		public static TokenType BracketIn				{ get { return TokenTypeRegistry.Get("bracketOpen"); } }
		public static TokenType BracketOut				{ get { return TokenTypeRegistry.Get("bracketClose"); } }
		public static TokenType BraceIn				{ get { return TokenTypeRegistry.Get("braceOpen"); } }
		public static TokenType BraceOut				{ get { return TokenTypeRegistry.Get("braceClose"); } }

		public static TokenType OperatorPlus			{ get { return TokenTypeRegistry.Get("operatorPlus"); } }
		public static TokenType OperatorMinus			{ get { return TokenTypeRegistry.Get("operatorMinus"); } }
		public static TokenType OperatorMultiply		{ get { return TokenTypeRegistry.Get("operatorMultiply"); } }
		public static TokenType OperatorDivide			{ get { return TokenTypeRegistry.Get("operatorDivide"); } }
		public static TokenType OperatorExponent		{ get { return TokenTypeRegistry.Get("operatorExponent"); } }

		public static TokenType OperatorModulus		{ get { return TokenTypeRegistry.Get("operatorModulus"); } }
		public static TokenType OperatorFactorial		{ get { return TokenTypeRegistry.Get("operatorFactorial"); } }

		public static TokenType OperatorNot			{ get { return TokenTypeRegistry.Get("operatorNot"); } }
		public static TokenType OperatorConditionalAnd	{ get { return TokenTypeRegistry.Get("operatorConditionalAnd"); } }
		public static TokenType OperatorConditionalOr	{ get { return TokenTypeRegistry.Get("operatorConditionalOr"); } }
		public static TokenType OperatorEqual			{ get { return TokenTypeRegistry.Get("operatorEqual"); } }
		public static TokenType OperatorNotEqual		{ get { return TokenTypeRegistry.Get("operatorNotEqual"); } }
		public static TokenType OperatorGreaterThan	{ get { return TokenTypeRegistry.Get("operatorGreaterThan"); } }
		public static TokenType OperatorLessThan		{ get { return TokenTypeRegistry.Get("operatorLessThan"); } }
		public static TokenType OperatorGreaterThanOrEqual		{ get { return TokenTypeRegistry.Get("operatorGreaterThanOrEqual"); } }
		public static TokenType OperatorLessThanOrEqual		{ get { return TokenTypeRegistry.Get("operatorLessThanOrEqual"); } }

		public static TokenType OperatorConcatenate	{ get { return TokenTypeRegistry.Get("operatorConcatenate"); } }

		public static TokenType OperatorQuestion		{ get { return TokenTypeRegistry.Get("operatorQuestion"); } }
		public static TokenType OperatorColon			{ get { return TokenTypeRegistry.Get("operatorColon"); } }

		public static TokenType Number					{ get { return TokenTypeRegistry.Get("number"); } }
		public static TokenType String					{ get { return TokenTypeRegistry.Get("string"); } }
		public static TokenType Boolean				{ get { return TokenTypeRegistry.Get("boolean"); } }

		public static TokenType Identifier				{ get { return TokenTypeRegistry.Get("identifier"); } }

		public static TokenType Unrecognized			{ get { return TokenTypeRegistry.Get("unrecognized"); } }
		#endregion
	}
}
