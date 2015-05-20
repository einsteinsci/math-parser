using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathPlusLib;

namespace MathParser.ParseTree
{
	public sealed class ResultNumberReal : IResultValue
	{
		public MathType Type
		{ get { return MathType.Real; } }

		public object CoreValue
		{ get { return Value; } }

		public double Value
		{ get; set; }

		public ResultNumberReal(double d)
		{
			Value = d;
		}

		public double ToDouble()
		{
			return Value;
		}

		public long ToInteger()
		{
			return (long)Value;
		}

		public MathMatrix ToMatrix()
		{
			return new MathMatrix(new double[,] { { Value } });
		}

		public override string ToString()
		{
			return Value.ToString();
		}
	}
}
