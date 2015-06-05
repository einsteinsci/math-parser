using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace MathParser.Tokens
{
	public abstract class TokenClass
	{
		public abstract bool Matches(string lexeme);
		
		public abstract int LexerPriority
		{ get; }

		public virtual bool IgnoreInTree
		{ get { return false; } }

		public virtual Dictionary<string, TokenClass> CustomRegistry
		{ get { return null; } }

		#region tokens
		public static TokenClass Comment				{ get { return TokenRegistry.Get("comment"); } }

		public static TokenClass Comma					{ get { return TokenRegistry.Get("comma"); } }

		public static TokenClass ParenthesisIn			{ get { return TokenRegistry.Get("parenthesisOpen"); } }
		public static TokenClass ParenthesisOut			{ get { return TokenRegistry.Get("parenthesisClose"); } }
		public static TokenClass BracketIn				{ get { return TokenRegistry.Get("bracketOpen"); } }
		public static TokenClass BracketOut				{ get { return TokenRegistry.Get("bracketClose"); } }
		public static TokenClass BraceIn				{ get { return TokenRegistry.Get("braceOpen"); } }
		public static TokenClass BraceOut				{ get { return TokenRegistry.Get("braceClose"); } }

		public static TokenClass OperatorPlus			{ get { return TokenRegistry.Get("operatorPlus"); } }
		public static TokenClass OperatorMinus			{ get { return TokenRegistry.Get("operatorMinus"); } }
		public static TokenClass OperatorMultiply		{ get { return TokenRegistry.Get("operatorMultiply"); } }
		public static TokenClass OperatorDivide			{ get { return TokenRegistry.Get("operatorDivide"); } }
		public static TokenClass OperatorExponent		{ get { return TokenRegistry.Get("operatorExponent"); } }

		public static TokenClass OperatorModulus		{ get { return TokenRegistry.Get("operatorModulus"); } }
		public static TokenClass OperatorBitShiftLeft	{ get { return TokenRegistry.Get("operatorBitShiftLeft"); } }
		public static TokenClass OperatorBitShiftRight	{ get { return TokenRegistry.Get("operatorBitShiftRight"); } }
		public static TokenClass OperatorFactorial		{ get { return TokenRegistry.Get("operatorFactorial"); } }

		public static TokenClass OperatorNot			{ get { return TokenRegistry.Get("operatorNot"); } }
		public static TokenClass OperatorConditionalAnd	{ get { return TokenRegistry.Get("operatorConditionalAnd"); } }
		public static TokenClass OperatorConditionalOr	{ get { return TokenRegistry.Get("operatorConditionalOr"); } }
		public static TokenClass OperatorEqual			{ get { return TokenRegistry.Get("operatorEqual"); } }
		public static TokenClass OperatorNotEqual		{ get { return TokenRegistry.Get("operatorNotEqual"); } }
		public static TokenClass OperatorGreaterThan	{ get { return TokenRegistry.Get("operatorGreaterThan"); } }
		public static TokenClass OperatorLessThan		{ get { return TokenRegistry.Get("operatorLessThan"); } }
		public static TokenClass OperatorGreaterThanOrEqual		{ get { return TokenRegistry.Get("operatorGreaterThanOrEqual"); } }
		public static TokenClass OperatorLessThanOrEqual		{ get { return TokenRegistry.Get("operatorLessThanOrEqual"); } }

		public static TokenClass OperatorConcatenate	{ get { return TokenRegistry.Get("operatorConcatenate"); } }

		public static TokenClass OperatorQuestion		{ get { return TokenRegistry.Get("operatorQuestion"); } }
		public static TokenClass OperatorColon			{ get { return TokenRegistry.Get("operatorColon"); } }

		public static TokenClass Number					{ get { return TokenRegistry.Get("number"); } }
		public static TokenClass String					{ get { return TokenRegistry.Get("string"); } }
		public static TokenClass Boolean				{ get { return TokenRegistry.Get("boolean"); } }

		public static TokenClass Identifier				{ get { return TokenRegistry.Get("identifier"); } }

		public static TokenClass Unrecognized			{ get { return TokenRegistry.Get("unrecognized"); } }
		#endregion
	}
}
