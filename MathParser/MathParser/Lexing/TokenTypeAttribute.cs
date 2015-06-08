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

		/// <summary>
		/// Whether the TokenType has a custom token registry to load from
		/// </summary>
		public bool Custom;
		
		/// <summary>
		/// Instantiates a TokenTypeAttribute
		/// </summary>
		public TokenTypeAttribute(string tokenName)
		{
			TokenName = tokenName.ToLower();
		}
	}
}
