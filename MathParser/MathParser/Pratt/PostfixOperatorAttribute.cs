﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Tokens;

namespace MathParser.Pratt
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	public class PostfixOperatorAttribute : Attribute
	{
		public TokenType TokenInstance
		{ get; private set; }

		public Type NodeType
		{ get; private set; }

		public PostfixOperatorAttribute(string instanceName, Type nodeType) : base()
		{
			TokenInstance = TokenTypeRegistry.Get(instanceName);
			NodeType = nodeType;
		}
	}
}
