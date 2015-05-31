using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	sealed class MakeTokenClassAttribute : Attribute
	{
		public string TokenName
		{ get; private set; }

		// named
		public bool Custom;

		public MakeTokenClassAttribute(string tokenName)
		{
			TokenName = tokenName.ToLower();
		}
	}
}
