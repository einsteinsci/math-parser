using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Tokens;

namespace MathParser.Pratt
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	public sealed class BinaryOperatorAttribute : Attribute
	{
		public TokenClass TokenInstance
		{ get; private set; }

		public Type NodeType
		{ get; private set; }

		public int PrecedenceLevel
		{ get; private set; }

		public bool IsRightAssociative
		{ get; private set; }

		public BinaryOperatorAttribute(string instanceName, Type nodeType, int precedence) : base()
		{
			TokenInstance = TokenRegistry.Get(instanceName);
			NodeType = nodeType;
			PrecedenceLevel = precedence;
			IsRightAssociative = false;
		}
	}
}
