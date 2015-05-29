using MathParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	public abstract class NodeOperatorUnary : NodeFactor
	{
		public virtual NodeFactor Term
		{ get; protected set; }

		public abstract string StringForm
		{ get; }

		public override List<NodeFactor> Children
		{
			get
			{
				return new List<NodeFactor>() { Term };
			}
		}

		public abstract TokenClass Operator
		{ get; }

		public override string ToString()
		{
			return "(" + StringForm + Term.ToString() + ")";
		}
	}
}
