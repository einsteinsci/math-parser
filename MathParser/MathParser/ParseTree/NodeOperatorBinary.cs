using MathParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	public abstract class NodeOperatorBinary : NodeFactor
	{
		public virtual NodeFactor First
		{ get; protected set; }

		public virtual NodeFactor Second
		{ get; protected set; }

		public abstract string StringForm
		{ get; }

		public override List<NodeFactor> Children
		{
			get
			{
				List<NodeFactor> res = new List<NodeFactor>();
				res.Add(First);
				res.Add(Second);
				return res;
			}
		}

		public abstract Token Operator
		{ get; }

		public virtual bool IsRightAssociative
		{ get { return false; } }

		public override string ToString()
		{
			return "(" + First.ToString() + " " + StringForm + " " + Second.ToString() + ")";
		}
	}
}
