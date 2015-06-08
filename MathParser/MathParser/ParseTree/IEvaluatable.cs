using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Types;

namespace MathParser.ParseTree
{
	/// <summary>
	/// Represents a type that can be evaluated in the parser
	/// </summary>
	public interface IEvaluatable
	{
		/// <summary>
		/// Evaluates the IEvaluatable
		/// </summary>
		/// <returns>The result value</returns>
		IResultValue Evaluate();
	}
}
