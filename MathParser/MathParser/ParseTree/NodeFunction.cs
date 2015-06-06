using MathParser.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Types;

namespace MathParser.ParseTree
{
	public class NodeFunction : NodeFactor
	{
		public override MathType Type
		{ get { return FuncInfo.ReturnType; } }

		public FunctionInfo FuncInfo
		{ get; protected set; }

		public override List<NodeFactor> Children
		{ get { return arguments; } }
		protected List<NodeFactor> arguments;

		public override string NodeName
		{ get { return FuncInfo.Name + "()"; } }

		public NodeFunction(FunctionInfo info, params NodeFactor[] args)
		{
			arguments = args.ToList();
			FuncInfo = info;
		}

		public override IResultValue GetResult()
		{
			List<IResultValue> argResults = new List<IResultValue>();
			foreach (NodeFactor fact in Children)
			{
				argResults.Add(fact.GetResult());
			}

			return FuncInfo.Invoke(argResults.ToArray());
		}

		public override string ToString()
		{
			string args = "";
			foreach (NodeFactor fact in Children)
			{
				args += fact.ToString() + ",";
			}
			args = args.TrimEnd(',');

			return FuncInfo.Name + "(" + args + ")";
		}
	}
}
