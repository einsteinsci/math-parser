using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Lexing;

namespace MathParser.Parsing
{
	/// <summary>
	/// Event args for PrefixLoadingEvent.
	/// </summary>
	public class PrefixLoadingEventArgs : EventArgs
	{
		/// <summary>
		/// Dictionary of existing prefix parselets.
		/// </summary>
		public Dictionary<TokenType, IPrefixParselet> Existing
		{ get; private set; }

		internal PrefixLoadingEventArgs(Dictionary<TokenType, IPrefixParselet> existing)
		{
			Existing = existing;
		}
	}
}
