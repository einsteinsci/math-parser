using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	public class OperatorMinus : OperatorBinary<double>
	{
		public override Tokens.Token Operator
		{
			get { return Tokens.Token.OperatorMinus; }
		}

		public override double GetResult()
		{
			return First.GetResult() - Second.GetResult();
		}
	}
}
