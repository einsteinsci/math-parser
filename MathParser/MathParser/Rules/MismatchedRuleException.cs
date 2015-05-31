using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Rules
{
	public class MismatchedRuleException : Exception
	{
		public Type Rule
		{ get; private set; }

		public MismatchedRuleException(Type rule, string message) : 
			this(message)
		{
			Rule = rule;
		}

		public MismatchedRuleException(string message) :
			base(message)
		{ }
	}
}
