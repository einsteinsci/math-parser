using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	sealed class TokenAttribute : Attribute
	{
		public string TokenName
		{ get; private set; }

		public TokenAttribute(string tokenName)
		{
			TokenName = tokenName.ToLower();
		}
	}
}
