using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Lexing
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	public sealed class TokenTypeAttribute : Attribute
	{
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
