using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.Tokens;

namespace MathParser.ParseTree
{
	public class OperatorModulus : OperatorBinary<double>
	{
		public override Token Operator
		{
			get { return Token.OperatorModulus; }
		}

		public override double GetResult()
		{
			return (int)First.GetResult() % (int)Second.GetResult();
		}

		public OperatorModulus(Factor<double> first, Factor<double> second)
		{
			First = first;
			Second = second;
		}
	}
}
