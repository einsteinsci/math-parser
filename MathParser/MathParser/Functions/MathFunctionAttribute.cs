using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Types;

namespace MathParser.Functions
{
	/// <summary>
	/// Specifies a method, property, or field to be a function in a library.
	/// Requires the containing class to have a FunctionLibraryAttribute applied.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Property)]
	public sealed class MathFunctionAttribute : Attribute
	{
		/// <summary>
		/// Name of function to be stored in registry
		/// </summary>
		public string Name
		{ get; private set; }

		/// <summary>
		/// Instantiates a new MathFunctionAttribute
		/// </summary>
		public MathFunctionAttribute(string name)
		{
			Name = name;
		}
	}
}
