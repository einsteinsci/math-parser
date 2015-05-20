using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	/// <summary>
	/// Not necessarily multiplication.
	/// </summary>
	public abstract class NodeFactor : IEvaluatable, ITextDisplayable
	{
		public abstract MathType Type
		{ get; }

		public abstract List<NodeFactor> Children
		{ get; }

		public abstract IResultValue GetResult();

		public virtual string GetResultString()
		{
			return GetResult().ToString();
		}
	}
}
