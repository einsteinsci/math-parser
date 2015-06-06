using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathPlusLib;

namespace MathParser.Types
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

		public bool ToBoolean()
		{
			return ToInteger() == 0 ? false : true;
		}

		public List<double> ToList()
		{
			return new List<double>() { ToDouble() };
		}

		public MathMatrix ToMatrix()
		{
			return new MathMatrix(new double[,] { { Value } });
		}

		public string ToDisplay()
		{
			return Value.ToString();
		}

		public override string ToString()
		{
			return Value.ToString();
		}
	}
}
