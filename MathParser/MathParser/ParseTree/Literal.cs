using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	public class Literal<T> : Factor<T>
	{
		public T Value
		{ get; set; }

		public override List<Factor<T>> Children
		{
			get { return new List<Factor<T>>(); }
		}

		public override T GetResult()
		{
			return Value;
		}

		public Literal(T val)
		{
			Value = val;
		}
	}
}
