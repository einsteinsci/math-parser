using MathPlusLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
	public class ResultNumberInteger : IResultValue
	{
		public MathType Type
		{ get { return MathType.Integer; } }

		public object CoreValue
		{ get { return Value; } }

		public long Value
		{ get; set; }

		public ResultNumberInteger(long value)
		{
			Value = value;
		}
		public ResultNumberInteger(int value)
		{
			Value = value;
		}

		public double ToDouble()
		{
			return (double)Value;
		}

		public long ToInteger()
		{
			return Value;
		}

		public bool ToBoolean()
		{
			return ToInteger() == 0 ? false : true;
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

		public static implicit operator ResultNumberReal(ResultNumberInteger _int)
		{
			return new ResultNumberReal(_int.ToDouble());
		}
	}
}
