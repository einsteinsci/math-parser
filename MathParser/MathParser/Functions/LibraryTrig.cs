using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathPlusLib;
using MathParser.Lexing;
using MathParser.Types;

namespace MathParser.Functions
{
	/// <summary>
	/// Trigonometric functions
	/// </summary>
	[FunctionLibrary("trig")]
	public class LibraryTrig
	{
		/// <summary>
		/// Sine function
		/// </summary>
		[MathFunction("sin")]
		public double Sine(double theta)
		{
			return MathPlus.Trig.Sin(theta);
		}

		/// <summary>
		/// Cosine function
		/// </summary>
		[MathFunction("cos")]
		public double Cosine(double theta)
		{
			return MathPlus.Trig.Cos(theta);
		}

		/// <summary>
		/// Tangent function
		/// </summary>
		[MathFunction("tan")]
		public double Tangent(double theta)
		{
			return MathPlus.Trig.Tan(theta);
		}

		/// <summary>
		/// Cosecant function
		/// </summary>
		[MathFunction("csc")]
		public double Cosecant(double theta)
		{
			return MathPlus.Trig.Csc(theta);
		}

		/// <summary>
		/// Secant function
		/// </summary>
		[MathFunction("sec")]
		public double Secant(double theta)
		{
			return MathPlus.Trig.Sec(theta);
		}

		/// <summary>
		/// Cotangent function
		/// </summary>
		[MathFunction("cot")]
		public double Cotangent(double theta)
		{
			return MathPlus.Trig.Cot(theta);
		}

		/// <summary>
		/// Inverse sine function
		/// </summary>
		[MathFunction("asin")]
		public double ArcSine(double ratio)
		{
			return MathPlus.Trig.ASin(ratio);
		}

		/// <summary>
		/// Inverse cosine function
		/// </summary>
		[MathFunction("acos")]
		public double ArcCosine(double ratio)
		{
			return MathPlus.Trig.ACos(ratio);
		}

		/// <summary>
		/// Inverse tangent function
		/// </summary>
		[MathFunction("atan")]
		public double ArcTangent(double ratio)
		{
			return MathPlus.Trig.ATan(ratio);
		}
	}
}
