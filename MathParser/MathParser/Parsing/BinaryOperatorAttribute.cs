using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Lexing;

namespace MathParser.Parsing
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	public sealed class BinaryOperatorAttribute : Attribute
	{
		public TokenType TokenInstance
		{ get; private set; }

		public Type NodeType
		{ get; private set; }

		public Precedence PrecedenceLevel
		{ get; private set; }

		public bool IsRightAssociative
		{ get; private set; }

		public BinaryOperatorAttribute(string instanceName, Type nodeType, Precedence precedence) : base()
		{
			TokenInstance = TokenTypeRegistry.Get(instanceName);
			NodeType = nodeType;
			PrecedenceLevel = precedence;
			IsRightAssociative = false;
		}
	}
}
