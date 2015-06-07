using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Functions
{
	/// <summary>
	/// Denotes a class to be a library of functions for the language
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public sealed class FunctionLibraryAttribute : Attribute
	{
		/// <summary>
		/// Name of function library
		/// </summary>
		public string LibName
		{ get; private set; }

		/// <summary>
		/// Instantiates a FunctionLibraryAttribute
		/// </summary>
		/// <param name="name">Name of function library</param>
		public FunctionLibraryAttribute(string name)
		{
			LibName = name.ToLower();
		}
	}
}
