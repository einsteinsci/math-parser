using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.Tokens;

namespace MathParser.ParseTree
{
	public class OperatorMultiply : OperatorBinary<double>
	{
		public override Token Operator
		{
			get { return Token.OperatorMultiply; }
		}

		public override double GetResult()
		{
			return First.GetResult() * Second.GetResult();
		}

		public OperatorMultiply(Factor<double> first, Factor<double> second)
		{
			First = first;
			Second = second;
		}
	}
}
