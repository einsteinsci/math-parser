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
	/// <typeparam name="T">Result type</typeparam>
	public abstract class Factor<T> : IEvaluatable<T>
	{
		public abstract List<Factor<T>> Children
		{ get; }

		public abstract T GetResult();
	}
}
