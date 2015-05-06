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

		public int Priority
		{ get; private set; }

		public TokenAttribute(string tokenName, int priority)
		{
			TokenName = tokenName.ToLower();
			Priority = priority;
		}
	}
}
