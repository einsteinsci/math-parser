using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.Tokens;

namespace MathParser.ParseTree
{
	public class OperatorPlus : OperatorBinary<double>
	{
		public override Token Operator
		{
			get { return Token.OperatorPlus; }
		}

		public override double GetResult()
		{
			return First.GetResult() + Second.GetResult();
		}
	}
}
