using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;

namespace MathParser
{
	[Serializable]
	public class EvaluationException : Exception
	{
		public NodeFactor InvalidFactor
		{ get; private set; }

		public EvaluationException(string message) : base(message)
		{ }

		public EvaluationException(NodeFactor factor, string message) : this(message)
		{
			InvalidFactor = factor;
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
		}
	}
}
