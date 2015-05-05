using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
	public static class TextUtils
	{
		public static bool IsWhitespace(this char c)
		{
			return c == ' ' || c == '\n' ||
				c == '\r' || c == '\t' || c == '\f';
		}

		public static bool IsAlphabetic(this char c)
		{
			int a = (int)'a';
			int z = (int)'z';
			int A = (int)'A';
			int Z = (int)'Z';

			int id = (int)c;
			return (id >= a && id <= z) || (id >= A && id <= Z);
		}

		public static bool IsNumeric(this char c)
		{
			int _0 = (int)'0';
			int _9 = (int)'9';

			return (int)c >= _0 && (int)c <= _9;
		}

		public static bool IsAlphaNumeric(this char c)
		{
			return c.IsAlphabetic() || c.IsNumeric();
		}
		public static bool IsValidVariable(this string s)
		{
			return s.All((c) => c.IsAlphaNumeric() || c == '_');
		}
	}
}
