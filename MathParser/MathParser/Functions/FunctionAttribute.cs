using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Functions
{
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple=false)]
	public sealed class FunctionAttribute : Attribute
	{
		public FunctionAttribute()
		{ }
	}
}
