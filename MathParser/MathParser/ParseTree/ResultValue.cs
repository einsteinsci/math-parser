using MathPlusLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	public enum MathType
	{
		Number = 0,
		String,
		Matrix
	}

	public interface ResultValue
	{
		MathType Type
		{ get; }

		object CoreValue
		{ get; }

		double ToDouble();
		MathMatrix ToMatrix();
	}
}
