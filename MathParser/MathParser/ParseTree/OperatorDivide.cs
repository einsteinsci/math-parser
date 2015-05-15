using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.Tokens;

namespace MathParser.ParseTree
{
	public class OperatorDivide : OperatorBinary<double>
	{
		public override Token Operator
		{
			get { return Token.OperatorDivide; }
		}

		public override double GetResult()
		{
			return First.GetResult() / Second.GetResult();
		}

		public OperatorDivide(Factor<double> first, Factor<double> second)
		{
			First = first;
			Second = second;
		}
	}
}
