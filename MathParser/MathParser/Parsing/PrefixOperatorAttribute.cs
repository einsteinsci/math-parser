using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Lexing;

namespace MathParser.Parsing
{
	/// <summary>
	/// Denotes a token class as a prefix operator.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	public sealed class PrefixOperatorAttribute : Attribute
	{
		/// <summary>
		/// Singleton instance of identifying token type
		/// </summary>
		public TokenType TokenInstance
		{ get; private set; }

		/// <summary>
		/// Type of node the operator creates when parsing. Must inherit from
		/// NodeOperatorUnary.
		/// </summary>
		public Type NodeType
		{ get; private set; }

		/// <summary>
		/// Instantiates a new PrefixOperatorAttribute.
		/// </summary>
		/// <param name="instanceName">Registry key of identifying token</param>
		/// <param name="nodeType">
		///   Type of node to create when parsing. Must inherit 
		///   from NodeOperatorUnary.
		/// </param>
		public PrefixOperatorAttribute(string instanceName, Type nodeType) : base()
		{
			TokenInstance = TokenTypeRegistry.Get(instanceName);
			NodeType = nodeType;
		}
	}
}
