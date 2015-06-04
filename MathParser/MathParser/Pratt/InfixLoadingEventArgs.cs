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
		public Dictionary<TokenClass, IInfixParselet> Existing
		{ get; private set; }

		internal InfixLoadingEventArgs(Dictionary<TokenClass, IInfixParselet> existing)
		{
			Existing = existing;
		}
	}
}
