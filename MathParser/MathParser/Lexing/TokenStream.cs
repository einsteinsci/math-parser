using MathParser.Lexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Lexing
{
	/// <summary>
	/// Stores tokens in a linear pattern for parsing.
	/// Not really a stream.
	/// </summary>
	public sealed class TokenStream : IEnumerable<Token>
	{
		/// <summary>
		/// Inner storage of tokens
		/// </summary>
		public List<Token> Tokens
		{ get; private set; }

		/// <summary>
		/// Gets a token at a given index
		/// </summary>
		/// <param name="index">Index of token</param>
		/// <returns>Token at index</returns>
		public Token this[int index]
		{
			get
			{
				return Tokens[index];
			}
			private set
			{
				Tokens[index] = value;
			}
		}

		/// <summary>
		/// Current index in "stream"
		/// </summary>
		public int Index
		{ get; private set; }

		/// <summary>
		/// Number of tokens in stream
		/// </summary>
		public int Count
		{
			get
			{
				return Tokens.Count;
			}
		}

		/// <summary>
		/// Instantiates a new TokenStream object
		/// </summary>
		public TokenStream()
		{
			Tokens = new List<Token>();
			Index = 0;
		}

		/// <summary>
		/// Instantiates a new TokenStream object
		/// </summary>
		public TokenStream(IEnumerable<Token> startData) : this()
		{
			Tokens.AddRange(startData);
		}

		/// <summary>
		/// Instantiates a new TokenStream object
		/// </summary>
		public TokenStream(params Token[] startData) : this()
		{
			Tokens.AddRange(startData);
		}

		/// <summary>
		/// Adds a token to tail of the stream
		/// </summary>
		/// <param name="tok">Token to add</param>
		public void Add(Token tok)
		{
			Tokens.Add(tok);
		}

		/// <summary>
		/// Adds tokens to the tail of the stream
		/// </summary>
		/// <param name="all">Tokens to add</param>
		public void AddRange(IEnumerable<Token> all)
		{
			Tokens.AddRange(all);
		}

		/// <summary>
		/// Inserts a token into the stream
		/// </summary>
		/// <param name="index">Index to insert at</param>
		/// <param name="tok">Token to add</param>
		public void Insert(int index, Token tok)
		{
			Tokens.Insert(index, tok);
		}

		/// <summary>
		/// Removes a token at a given index
		/// </summary>
		/// <param name="index">Index of token to remove</param>
		public void RemoveAt(int index)
		{
			Tokens.RemoveAt(index);
			Type t = typeof(void);
		}

		/// <summary>
		/// Removes a token
		/// </summary>
		/// <param name="rem">Token to remove</param>
		/// <returns>True if removal was successful, false otherwise</returns>
		public bool Remove(Token rem)
		{
			return Tokens.Remove(rem);
		}

		/// <summary>
		/// Returns whether the stream is empty or not
		/// </summary>
		/// <returns>True if the stream is empty, false if not</returns>
		public bool IsEmpty()
		{
			return Count > 0;
		}

		/// <summary>
		/// Advances position within stream
		/// </summary>
		/// <returns>Token at Index</returns>
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

		/// <summary>
		/// Shows next token in stream without advancing Index
		/// </summary>
		/// <param name="ahead">Number of tokens ahead to look after next</param>
		/// <returns>Token peeked at</returns>
		public Token Peek(int ahead = 0)
		{
			return this[Index + ahead];
		}

		/// <summary>
		/// Regresses position within stream backward
		/// </summary>
		/// <returns>Token before Index</returns>
		public Token Previous()
		{
			Index--;
			return this[Index];
		}

		/// <summary>
		/// Resets position of Index to start, or a given index
		/// </summary>
		/// <param name="index"></param>
		public void Reset(int index = 0)
		{
			Index = index;
		}

		/// <summary>
		/// Gets whether there are tokens left in the stream.
		/// </summary>
		/// <returns>True if there are tokens left, false if not</returns>
		public bool HasNext()
		{
			return Index < Count;
		}

		/// <summary>
		/// Gets the IEnumerator for the IEnumerable
		/// </summary>
		public IEnumerator<Token> GetEnumerator()
		{
			return Tokens.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return Tokens.GetEnumerator();
		}

		/// <summary>
		/// Lists the tokens into a string
		/// </summary>
		public override string ToString()
		{
			string res = "";
			foreach (Token lex in Tokens)
			{
				res += lex + " ";
			}
			return res.Trim();
		}
	}
}
