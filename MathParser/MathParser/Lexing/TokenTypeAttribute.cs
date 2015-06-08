using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Lexing
{
	/// <summary>
	/// Denotes the class should be instantiated via reflection and loaded into the 
	/// token type registry.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	public sealed class TokenTypeAttribute : Attribute
	{
		/// <summary>
		/// ID of token
		/// </summary>
		public string TokenName
		{ get; private set; }

		// named
		public bool Custom;

		public TokenTypeAttribute(string tokenName)
		{
			TokenName = tokenName.ToLower();
		}
	}
}
