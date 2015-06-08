using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;

namespace MathParser
{
	/// <summary>
	/// Exception that occurs during evaluation
	/// </summary>
	[Serializable]
	public class EvaluationException : Exception
	{
		/// <summary>
		/// Factor that caused the exception
		/// </summary>
		public NodeBase InvalidFactor
		{ get; private set; }

		/// <summary>
		/// Instantiates an EvaluationException
		/// </summary>
		/// <param name="message">Exception message</param>
		public EvaluationException(string message) : base(message)
		{ }

		/// <summary>
		/// Instantiates an EvaluationException
		/// </summary>
		/// <param name="factor">Factor causing the exception</param>
		/// <param name="message">Exception message</param>
		public EvaluationException(NodeBase factor, string message) : this(message)
		{
			InvalidFactor = factor;
		}

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
