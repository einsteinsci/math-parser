using MathPlusLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Types
{
	public enum MathType
	{
		Real = 0,
		Integer,
		String,
		Boolean,
		List,
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
		bool ToBoolean();
		MathMatrix ToMatrix();
		List<double> ToList();
		string ToDisplay();
	}
}
