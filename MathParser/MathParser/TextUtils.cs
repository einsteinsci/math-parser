using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
	/// <summary>
	/// Static class containing various text-related extension methods
	/// </summary>
	public static class TextUtils
	{
		/// <summary>
		/// Returns true if a character is a whitespace character
		/// </summary>
		/// <param name="c">Character to check</param>
		/// <returns>True if c is whitespace, false otherwise</returns>
		public static bool IsWhitespace(this char c)
		{
			return c == ' ' || c == '\n' ||
				c == '\r' || c == '\t' || c == '\f';
		}

		/// <summary>
		/// Returns true if a character is an alphabetic character
		/// </summary>
		/// <param name="c">Character to check</param>
		/// <returns>True if c is a letter, false otherwise</returns>
		public static bool IsAlphabetic(this char c)
		{
			int a = 'a';
			int z = 'z';
			int A = 'A';
			int Z = 'Z';
			
			return (c >= a && c <= z) || (c >= A && c <= Z);
		}

		/// <summary>
		/// Returns true if a character is a numeric character
		/// </summary>
		/// <param name="c">Character to check</param>
		/// <returns>True if c is a digit, false otherwise</returns>
		public static bool IsNumeric(this char c)
		{
			int _0 = '0';
			int _9 = '9';

			return c >= _0 && c <= _9;
		}

		/// <summary>
		/// Returns true if a character is alphanumeric
		/// </summary>
		/// <param name="c">Character to check</param>
		/// <returns>True if c is alphanumeric, false otherwise</returns>
		public static bool IsAlphaNumeric(this char c)
		{
			return c.IsAlphabetic() || c.IsNumeric();
		}

		/// <summary>
		/// Returns true if a string is a valid c-style identifier
		/// </summary>
		/// <param name="s">String to check</param>
		/// <returns>True if a string is a valid identifier, false otherwise</returns>
		public static bool IsValidVariable(this string s)
		{
			if (!s[0].IsAlphaNumeric())
			{
				return false;
			}

			return s.All((c) => c.IsAlphaNumeric() || c == '_');
		}
	}
}
