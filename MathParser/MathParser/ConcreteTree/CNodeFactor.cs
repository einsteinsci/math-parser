using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Lexing;

namespace MathParser.ConcreteTree
{
	/// <summary>
	/// Stands for Concrete (as in CST) Node Factor. Has nothing 
	/// to do with multiplication.
	/// </summary>
	public class CNodeFactor : INonTerminal
	{
		public bool CanAccept(INonTerminal parent, TokenStream stream)
		{
			//CNodeAssignment asgn = new CNodeAssignment();
			//if (asgn.CanAccept())
			//{
			//	return true;
			//}
			//
			//CNodePostfix pfx = new CNodePostfix();
			//return pfx.CanAccept();

			return false;
		}

		public bool Expect(INonTerminal parent, TokenStream stream)
		{
			throw new NotImplementedException();
		}
	}
}
