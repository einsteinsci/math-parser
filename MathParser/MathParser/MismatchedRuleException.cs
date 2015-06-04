using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
	[Serializable]
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

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
		}
	}
}
