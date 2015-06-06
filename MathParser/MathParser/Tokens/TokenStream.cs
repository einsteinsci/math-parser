using MathParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Tokens
{
	/// <summary>
	/// Not really a stream
	/// </summary>
	public sealed class TokenStream : IEnumerable<Token>
	{
		public List<Token> Lexemes
		{ get; private set; }

		public Token this[int index]
		{
			get
			{
				return Lexemes[index];
			}
			private set
			{
				Lexemes[index] = value;
			}
		}

		public int Index
		{ get; private set; }

		public int Count
		{
			get
			{
				return Lexemes.Count;
			}
		}

		public TokenStream()
		{
			Lexemes = new List<Token>();
			Index = 0;
		}

		public TokenStream(IEnumerable<Token> startData) : this()
		{
			Lexemes.AddRange(startData);
		}

		public TokenStream(params Token[] startData) : this()
		{
			Lexemes.AddRange(startData);
		}

		public void Add(Token lex)
		{
			Lexemes.Add(lex);
		}

		public void AddRange(IEnumerable<Token> all)
		{
			Lexemes.AddRange(all);
		}

		public void Insert(int index, Token lex)
		{
			Lexemes.Insert(index, lex);
		}

		public void RemoveAt(int index)
		{
			Lexemes.RemoveAt(index);
			Type t = typeof(void);
		}

		public bool Remove(Token rem)
		{
			return Lexemes.Remove(rem);
		}

		public bool IsEmpty()
		{
			return Count > 0;
		}

		public Token Next()
		{
			if (Index >= Count)
			{
				return null;
			}

			Token res = this[Index];
			Index++;
			return res;
		}

		public Token Peek(int ahead = 0)
		{
			return this[Index + ahead];
		}

		public Token Previous()
		{
			Index--;
			return this[Index];
		}

		public void Reset(int index = 0)
		{
			Index = index;
		}

		public bool HasNext()
		{
			return Index < Count;
		}

		public IEnumerator<Token> GetEnumerator()
		{
			return Lexemes.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return Lexemes.GetEnumerator();
		}

		public override string ToString()
		{
			string res = "";
			foreach (Token lex in Lexemes)
			{
				res += lex + " ";
			}
			return res.Trim();
		}
	}
}
