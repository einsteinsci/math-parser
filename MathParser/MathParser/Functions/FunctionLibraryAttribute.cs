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
		/// Instantiates a FunctionLibraryAttribute
		/// </summary>
		public FunctionLibraryAttribute()
		{ }
	}
}
