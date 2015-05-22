using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public sealed class FunctionLibraryAttribute : Attribute
	{
		public string LibName
		{ get; private set; }

		public FunctionLibraryAttribute(string name)
		{
			LibName = name.ToLower();
		}
	}
}
