using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	public class NodeFunction : NodeFactor
	{
		public override MathType Type
		{ get { return FuncInfo.ReturnType; } }

		public FunctionInfo FuncInfo
		{ get; protected set; }

		public override List<NodeFactor> Children
		{
			get { return arguments; }
		}
		protected List<NodeFactor> arguments;

		public NodeFunction(FunctionInfo info, params NodeFactor[] args)
		{
			arguments = args.ToList();
			FuncInfo = info;
		}

		public override ResultValue GetResult()
		{
			throw new NotImplementedException();
		}
	}
}
