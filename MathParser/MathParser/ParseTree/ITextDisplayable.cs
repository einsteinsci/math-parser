using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	/// <summary>
	/// Represents a type that has a display-specific string function
	/// </summary>
	public interface ITextDisplayable
	{
		/// <summary>
		/// Gets the display string of the object
		/// </summary>
		string ToDisplayString();
	}
}
