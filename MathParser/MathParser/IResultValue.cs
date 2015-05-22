using MathPlusLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
	public enum MathType
	{
		Real = 0,
		Integer,
		String,
		Matrix
	}

	public interface IResultValue
	{
		MathType Type
		{ get; }

		object CoreValue
		{ get; }

		double ToDouble();
		long ToInteger();
		MathMatrix ToMatrix();
	}
}
