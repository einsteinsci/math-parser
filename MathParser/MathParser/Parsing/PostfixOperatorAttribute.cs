using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Lexing;

namespace MathParser.Parsing
{
	/// <summary>
	/// Denotes a token class as a standard postfix operator
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	public class PostfixOperatorAttribute : Attribute
	{
		/// <summary>
		/// Singleton instance of identifying token
		/// </summary>
		public TokenType TokenInstance
		{ get; private set; }

		/// <summary>
		/// Type of node the operator creates when parsing. Must
		/// inherit from NodeOperatorUnary.
		/// </summary>
		public Type NodeType
		{ get; private set; }

		/// <summary>
		/// Instantiates a new PostfixOperatorAttribute
		/// </summary>
		/// <param name="instanceName">Registry name of token</param>
		/// <param name="nodeType">
		///   Type of node to create. Must inherit from 
		///	  NodeOperatorUnary.
		/// </param>
		public PostfixOperatorAttribute(string instanceName, Type nodeType) : base()
		{
			TokenInstance = TokenTypeRegistry.Get(instanceName);
			NodeType = nodeType;
		}
	}
}
