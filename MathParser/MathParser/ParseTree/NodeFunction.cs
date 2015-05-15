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

		public FunctionInfo Function
		{ get; private set; }

		public NodeFunction(FunctionInfo func)
		{
			Function = func;
		}

		public override T GetResult()
		{
			List<object> argumentValues = new List<object>();
			for (int i = 0; i < Function.Arguments.Length; i++)
			{
				if (Function.Arguments[i].IsAssignableFrom(argumentValues[i].GetType()))
				{
					throw new ArgumentException("Cannot assign " + 
						argumentValues[i].GetType().ToString() + 
						" to " + Function.Arguments[i].ToString());
				}
			}

			foreach (Factor<T> factor in arguments)
			{
				argumentValues.Add(factor.GetResult());
			}

			return (T)((IConvertible)Function.Evaluate(argumentValues.ToArray())).ToType(typeof(T), null);
		}
	}
}
