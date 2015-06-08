using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Types;

namespace MathParser.ParseTree
{
	public class NodeOperatorConditional : NodeBase
	{
		public override MathType Type
		{ get { return OnTrue.Type; } }

		public override List<NodeBase> Children
		{
			get 
			{
				return new List<NodeBase>() {
					Condition,
					OnTrue,
					OnFalse
				};
			}
		}

		public override string NodeName
		{ get { return "Operator ?:"; } }

		public NodeBase Condition
		{ get; private set; }

		public NodeBase OnTrue
		{ get; private set; }

		public NodeBase OnFalse
		{ get; private set; }

		public NodeOperatorConditional(NodeBase condition, NodeBase onTrue, NodeBase onFalse)
		{
			Condition = condition;
			OnTrue = onTrue;
			OnFalse = onFalse;
		}

		public override IResultValue Evaluate()
		{
			IResultValue condition = Condition.Evaluate();
			if (condition.Type != MathType.Boolean)
			{
				throw new EvaluationException(this, 
					"Condition part of conditional operator must be boolean.");
			}

			// See what I mean here?
			return condition.ToBoolean() ? OnTrue.Evaluate() : OnFalse.Evaluate();
		}
	}
}
