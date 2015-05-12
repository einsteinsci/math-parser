using MathParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	public abstract class OperatorBinary<T> : Factor<T>
	{
		public virtual Factor<T> First
		{ get; protected set; }

		public virtual Factor<T> Second
		{ get; protected set; }

		public override List<Factor<T>> Children
		{
			get
			{
				List<Factor<T>> res = new List<Factor<T>>();
				res.Add(First);
				res.Add(Second);
				return res;
			}
		}

		public abstract Token Operator
		{ get; }

		public virtual bool IsRightAssociative
		{ get { return false; } }
	}
}
