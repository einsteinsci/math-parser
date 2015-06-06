using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathPlusLib;

namespace MathParser.Types
{
	public class ResultBoolean : IResultValue
	{
		public object CoreValue
		{ get { return Value; } }

		public bool Value
		{ get; set; }

		public MathType Type
		{ get { return MathType.Boolean; } }

		public ResultBoolean(bool value)
		{
			Value = value;
		}

		public string ToDisplay()
		{
			return ToString();
		}

		public double ToDouble()
		{
			return (double)ToInteger();
		}

		public long ToInteger()
		{
			return Value ? 1 : 0;
		}

		public bool ToBoolean()
		{
			return Value;
		}

		public List<double> ToList()
		{
			return new List<double>() { ToDouble() };
		}

		public MathMatrix ToMatrix()
		{
			return new MathMatrix(new double[,] { { ToDouble() } });
		}

		public override string ToString()
		{
			return Value ? "true" : "false";
		}
	}
}
