using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Tokens;

namespace MathParser.Pratt
{
	public class PrefixLoadingEventArgs : EventArgs
	{
		public Dictionary<TokenType, IPrefixParselet> Existing
		{ get; private set; }

		internal PrefixLoadingEventArgs(Dictionary<TokenType, IPrefixParselet> existing)
		{
			Existing = existing;
		}
	}
}
