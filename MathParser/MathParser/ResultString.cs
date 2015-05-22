using MathPlusLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
	public sealed class ResultString : IResultValue
	{
		public MathType Type
		{ get { return MathType.String; } }

		public object CoreValue
		{ get { return Value; } }

		public string Value
		{ get; set; }

		public ResultString(string s)
		{
			Value = s;
		}

		public double ToDouble()
		{
			return double.Parse(Value);
		}

		public long ToInteger()
		{
			return long.Parse(Value);
		}

		public MathMatrix ToMatrix()
		{
			return new MathMatrix(new double[,] { { ToDouble() } });
		}

		public override string ToString()
		{
			return "\"" + Value + "\"";
		}
	}
}
