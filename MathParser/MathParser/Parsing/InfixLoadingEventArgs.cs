using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Lexing;

namespace MathParser.Parsing
{
	/// <summary>
	/// Event arguments for InfixLoadingEvent
	/// </summary>
	public class InfixLoadingEventArgs : EventArgs
	{
		/// <summary>
		/// Dictionary of existing infix parselets
		/// </summary>
		public Dictionary<TokenType, IInfixParselet> Existing
		{ get; private set; }
		
		internal InfixLoadingEventArgs(Dictionary<TokenType, IInfixParselet> existing)
		{
			Existing = existing;
		}
	}
}
