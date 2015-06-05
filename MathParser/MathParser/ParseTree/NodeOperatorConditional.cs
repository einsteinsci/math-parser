using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	public class NodeOperatorConditional : NodeFactor
	{
		public override MathType Type
		{ get { return OnTrue.Type; } }

		public override List<NodeFactor> Children
		{
			get 
			{
				return new List<NodeFactor>() {
					Condition,
					OnTrue,
					OnFalse
				};
			}
		}

		public override string NodeName
		{ get { return "Operator ?:"; } }

		public NodeFactor Condition
		{ get; private set; }

		public NodeFactor OnTrue
		{ get; private set; }

		public NodeFactor OnFalse
		{ get; private set; }

		public NodeOperatorConditional(NodeFactor condition, NodeFactor onTrue, NodeFactor onFalse)
		{
			Condition = condition;
			OnTrue = onTrue;
			OnFalse = onFalse;
		}

		public override IResultValue GetResult()
		{
			IResultValue condition = Condition.GetResult();
			if (condition.Type != MathType.Boolean)
			{
				throw new ArgumentException("Condition part of conditional operator must be boolean.");
			}

			// See what I mean here?
			return condition.ToBoolean() ? OnTrue.GetResult() : OnFalse.GetResult();
		}
	}
}
