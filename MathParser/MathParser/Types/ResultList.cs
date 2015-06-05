using MathPlusLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
	public class ResultList : IResultValue
	{
		public MathType Type
		{ get { return MathType.List; } }

		public object CoreValue
		{ get { return Value; } }

		public List<double> Value
		{ get; private set; }

		public ResultList(List<double> value)
		{
			Value = value;
		}
		public ResultList() : this(new List<double>())
		{ }
		public ResultList(params double[] value) : this(value.ToList())
		{ }

		public double ToDouble()
		{
			return Value.FirstOrDefault();
		}

		public long ToInteger()
		{
			return (long)ToDouble();
		}

		public bool ToBoolean()
		{
			return ToDouble() != 0;
		}

		public MathMatrix ToMatrix()
		{
			MathMatrix res = new MathMatrix(Value.Count, 1);
			for (int i = 0; i < Value.Count; i++)
			{
				res[i, 0] = Value[i];
			}

			return res;
		}

		public List<double> ToList()
		{
			return Value;
		}

		public string ToDisplay()
		{
			return ToString();
		}

		public override string ToString()
		{
			string res = "{ ";
			for (int i = 0; i < Value.Count; i++)
			{
				res += Value[i].ToString();

				if (i < Value.Count - 1)
				{
					res += ", ";
				}
			}

			return res + " }";
		}
	}
}
