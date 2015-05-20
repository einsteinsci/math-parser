using MathParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Lexing
{
	/// <summary>
	/// Not really a stream
	/// </summary>
	public sealed class LexStream : IEnumerable<Lexeme>
	{
		public List<Lexeme> Lexemes
		{ get; private set; }

		public Lexeme this[int index]
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

		public LexStream()
		{
			Lexemes = new List<Lexeme>();
			Index = 0;
		}

		public LexStream(IEnumerable<Lexeme> startData) : this()
		{
			Lexemes.AddRange(startData);
		}

		public LexStream(params Lexeme[] startData) : this()
		{
			Lexemes.AddRange(startData);
		}

		public void Add(Lexeme lex)
		{
			Lexemes.Add(lex);
		}

		public void AddRange(IEnumerable<Lexeme> all)
		{
			Lexemes.AddRange(all);
		}

		public void Insert(int index, Lexeme lex)
		{
			Lexemes.Insert(index, lex);
		}

		public void RemoveAt(int index)
		{
			Lexemes.RemoveAt(index);
			Type t = typeof(void);
		}

		public bool Remove(Lexeme rem)
		{
			return Lexemes.Remove(rem);
		}

		public bool IsEmpty()
		{
			return Count > 0;
		}

		public Lexeme Next()
		{
			Lexeme res = this[Index];
			Index++;
			return res;
		}

		public void Reset()
		{
			Index = 0;
		}

		public bool HasNext()
		{
			return Index < Count;
		}

		public IEnumerator<Lexeme> GetEnumerator()
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
			foreach (Lexeme lex in Lexemes)
			{
				res += lex + " ";
			}
			return res.Trim();
		}
	}
}
