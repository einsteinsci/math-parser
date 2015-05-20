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

		public int Priority
		{ get; private set; }

		// named
		public bool Custom;

		public MakeTokenAttribute(string tokenName, int priority)
		{
			TokenName = tokenName.ToLower();
			Priority = priority;
		}
	}
}
