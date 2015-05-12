using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathParser.Tokens;
using MathPlusLib;

namespace MathParser.ParseTree
{
	public class OperatorExponent : OperatorBinary<double>
	{
		public override Token Operator
		{
			get { return Token.OperatorExponent; }
		}

		public override double GetResult()
		{
			return MathPlus.Pow(First.GetResult(), Second.GetResult());
		}
	}
}
