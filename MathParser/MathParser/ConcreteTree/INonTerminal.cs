using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Lexing;

namespace MathParser.ConcreteTree
{
	public interface INonTerminal
	{
		bool CanAccept(INonTerminal parent, TokenStream stream);
		
		// return false to error.
		bool Expect(INonTerminal parent, TokenStream stream);
	}
}
