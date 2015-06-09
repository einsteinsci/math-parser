using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Lexing;

namespace MathParser.Parsing
{
	/// <summary>
	/// Marks a token as part of a standard binary operator, with
	/// the necessary values to describe the operator.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	public sealed class BinaryOperatorAttribute : Attribute
	{
		/// <summary>
		/// Instance of token once loaded;
		/// </summary>
		public TokenType TokenInstance
		{ get; private set; }

		/// <summary>
		/// Type of the Node class describing the operator. It must
		/// inherit from NodeOperatorBinary
		/// </summary>
		public Type NodeType
		{ get; private set; }

		/// <summary>
		/// Precedence level of operator
		/// </summary>
		public Precedence PrecedenceLevel
		{ get; private set; }

		/// <summary>
		/// True if the operator is right-associative, false if not.
		/// Name this argument to change it.
		/// </summary>
		public bool IsRightAssociative
		{ get; private set; }

		/// <summary>
		/// Instantiates a new BinaryOperatorAttribute
		/// </summary>
		/// <param name="instanceName">Registry name of token</param>
		/// <param name="nodeType">
		///   Type of node to create when parsing. Must inherit from
		///   NodeOperatorBinary.
		/// </param>
		/// <param name="precedence">Precedence level of operator.</param>
		public BinaryOperatorAttribute(string instanceName, Type nodeType, Precedence precedence) : base()
		{
			TokenInstance = TokenTypeRegistry.Get(instanceName);
			NodeType = nodeType;
			PrecedenceLevel = precedence;
			IsRightAssociative = false;
		}
	}
}
