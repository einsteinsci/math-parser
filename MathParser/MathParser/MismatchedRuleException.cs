using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
	/// <summary>
	/// An exception that is due to a syntax rule being broken
	/// </summary>
	[Serializable]
	public class MismatchedRuleException : Exception
	{
		/// <summary>
		/// Instantiates a MismatchedRuleException
		/// </summary>
		/// <param name="message">Exception message</param>
		public MismatchedRuleException(string message) :
			base(message)
		{ }

		/// <summary>
		/// Gets the object data, inherited from CLR type _Exception
		/// </summary>
		/// <param name="info">Serialization Info</param>
		/// <param name="context">Streaming Context</param>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
		}
	}
}
