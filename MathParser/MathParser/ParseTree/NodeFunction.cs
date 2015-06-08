using MathParser.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Types;

namespace MathParser.ParseTree
{
	public class NodeFunction : NodeBase
	{
		public override MathType Type
		{ get { return FuncInfo.ReturnType; } }

		public FunctionInfo FuncInfo
		{ get; protected set; }

		public override List<NodeBase> Children
		{ get { return arguments; } }
		protected List<NodeBase> arguments;

		public override string NodeName
		{ get { return FuncInfo.Name + "()"; } }

		public NodeFunction(FunctionInfo info, params NodeBase[] args)
		{
			arguments = args.ToList();
			FuncInfo = info;
		}

		public override IResultValue Evaluate()
		{
			List<IResultValue> argResults = new List<IResultValue>();
			foreach (NodeBase fact in Children)
			{
				argResults.Add(fact.Evaluate());
			}

			return FuncInfo.Invoke(argResults.ToArray());
		}

		public override string ToString()
		{
			string args = "";
			foreach (NodeBase fact in Children)
			{
				args += fact.ToString() + ",";
			}
			args = args.TrimEnd(',');

			return FuncInfo.Name + "(" + args + ")";
		}
	}
}
