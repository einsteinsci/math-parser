using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Types;

namespace MathParser.Functions
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Property)]
	public sealed class MathFunctionAttribute : Attribute
	{
		public string Name
		{ get; private set; }

		public MathFunctionAttribute(string name)
		{
			Name = name;
		}
	}
}
