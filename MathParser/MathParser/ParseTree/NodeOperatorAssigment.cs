using MathParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	public class NodeOperatorAssigment : NodeOperatorBinary
	{
		public override string StringForm
		{ get { return ":="; } }

		public override bool IsRightAssociative
		{ get { return true; } }

		public override TokenClass Operator
		{ get { return TokenClass.OperatorAssignment; } }

		public override MathType Type
		{ get { return First.Type; } }

		public NodeOperatorAssigment(NodeFactor first, NodeFactor second)
		{
			First = first;
			Second = second;
		}

		public override IResultValue GetResult()
		{
			if (!(First is NodeIdentifier))
			{
				throw new InvalidCastException("Cannot assign value to anything but an identifier");
			}

			NodeIdentifier idFirst = First as NodeIdentifier;
			IResultValue res = Second.GetResult();
			string name = idFirst.VariableName;

			if (VariableRegistry.Global.ContainsVariable(name))
			{
				VariableRegistry.Set(name, res);
			}
			else
			{
				VariableRegistry.Global.Create(name, res);
			}

			return res;
		}
	}
}
