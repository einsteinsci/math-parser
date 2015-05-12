using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.Tokens;

namespace MathParser.ParseTree
{
	public class NodeFunction<T> : Factor<T>
	{
		public override List<Factor<T>> Children
		{ get { return arguments; } }
		private List<Factor<T>> arguments;

		public MathFunc<T> Function
		{ get; private set; }

		public NodeFunction(MathFunc<T> func)
		{
			Function = func;
		}

		public override T GetResult()
		{
			List<object> argumentValues = new List<object>();
			// TODO: Check argument types

			foreach (Factor<T> factor in arguments)
			{
				argumentValues.Add(factor.GetResult());
			}

			return Function.Evaluate(argumentValues.ToArray());
		}
	}
}
