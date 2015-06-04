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
		public Dictionary<TokenClass, IPrefixParselet> Existing
		{ get; private set; }

		internal PrefixLoadingEventArgs(Dictionary<TokenClass, IPrefixParselet> existing)
		{
			Existing = existing;
		}
	}
}
