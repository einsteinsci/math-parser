using MathParser.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	public sealed class ParserLALR
	{
		public TokenStream Stream
		{ get; private set; }

		public NodeFactor Root
		{ get; private set; }

		public void Parse()
		{

		}
	}
}
