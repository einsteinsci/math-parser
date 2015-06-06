using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Tokens;

namespace MathParser.Pratt
{
	public class InfixLoadingEventArgs : EventArgs
	{
		public Dictionary<TokenType, IInfixParselet> Existing
		{ get; private set; }

		internal InfixLoadingEventArgs(Dictionary<TokenType, IInfixParselet> existing)
		{
			Existing = existing;
		}
	}
}
