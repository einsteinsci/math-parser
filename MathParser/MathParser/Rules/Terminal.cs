﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Lexing;

namespace MathParser.Rules
{
	public class Terminal : ITerm
	{
		public Token ExpectedToken
		{ get; private set; }

		public bool Matches(ITerm state, Token next)
		{
			return next == ExpectedToken;
		}
	}
}