using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	sealed class MakeTokenAttribute : Attribute
	{
		public string TokenName
		{ get; private set; }

		// named
		public bool Custom;

		public MakeTokenAttribute(string tokenName)
		{
			TokenName = tokenName.ToLower();
		}
	}
}
