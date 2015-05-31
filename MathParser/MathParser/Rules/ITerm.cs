using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Lexing;

namespace MathParser.Rules
{
	public interface ITerm
	{
		bool Matches(ITerm state, Token next);
	}
}
