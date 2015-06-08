using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Lexing;

namespace MathParser.Parsing
{
	/// <summary>
	/// Class containing all regular binary operators
	/// </summary>
	public static class BinaryInfixRegistry
	{
		static Dictionary<TokenType, RegItem> registry =
			new Dictionary<TokenType, RegItem>();

		static BinaryInfixRegistry()
		{
			Init();
		}

		/// <summary>
		/// Initializes and loads binary operators via reflection
		/// </summary>
		public static void Init()
		{
			List<Type> infixes = Extensibility.
				GetAllTypesWithAttribute(typeof(BinaryOperatorAttribute));

			foreach (Type t in infixes)
			{
				object obj = t.GetCustomAttributes(typeof(BinaryOperatorAttribute), 
					false).FirstOrDefault();
				BinaryOperatorAttribute att = obj as BinaryOperatorAttribute;

				if (att == null)
				{
					Logger.Log(LogLevel.Error, Logger.REGISTRY,
						"Attribute is null!");

					System.Diagnostics.Debugger.Break();
				}

				Register(att.TokenInstance, att.NodeType, att.PrecedenceLevel, 
					att.IsRightAssociative);
			}
		}

		/// <summary>
		/// Registers a token type for a binary operator
		/// </summary>
		/// <param name="token">Token type in between operator sides</param>
		/// <param name="nodeType">Type of node to register to</param>
		/// <param name="precedence">Precedence level of operator</param>
		/// <param name="rightAssociative">Whether the operator is right-associative</param>
		public static void Register(TokenType token, Type nodeType, 
			Precedence precedence, bool rightAssociative = false)
		{
			Type _nodeOperatorBinary = typeof(NodeOperatorBinary);
			if (!_nodeOperatorBinary.IsAssignableFrom(nodeType))
			{
				throw new InvalidCastException(
					"Cannot register binary infix operator without binary node.");
			}

			RegItem val = new RegItem(nodeType, precedence, rightAssociative);

			if (registry.ContainsKey(token))
			{
				Logger.Log(LogLevel.Warning, Logger.REGISTRY,
					"Key for " + token.ToString() + " already exists. Replacing with type " +
					val.NodeType.ToString() + ".");
				registry[token] = val;
			}
			else
			{
				registry.Add(token, val);
			}
		}

		/// <summary>
		/// Creates a node from a token and two sides
		/// </summary>
		/// <param name="token">Token identifying the operator</param>
		/// <param name="left">Left side of operator</param>
		/// <param name="right">Right side of operator</param>
		/// <returns>Node of the tokens</returns>
		public static NodeOperatorBinary MakeNode(TokenType token, 
			NodeBase left, NodeBase right)
		{
			if (!registry.ContainsKey(token))
			{
				throw new ArgumentOutOfRangeException(
					"Token does not exist in registry.");
			}

			Type nodeType = registry[token].NodeType;

			object obj = Activator.CreateInstance(nodeType, left, right);

			return obj as NodeOperatorBinary;
		}

		public static RegItem Get(TokenType key)
		{
			return registry[key];
		}

		public static List<TokenType> GetTokens()
		{
			return registry.Keys.ToList();
		}

		public sealed class RegItem
		{
			public Type NodeType
			{ get; private set; }

			public Precedence PrecedenceLevel
			{ get; private set; }

			public bool IsRightAssociative
			{ get; private set; }

			public RegItem(Type nodeType, Precedence precedence, bool rightAssociative = false)
			{
				NodeType = nodeType;
				PrecedenceLevel = precedence;
				IsRightAssociative = rightAssociative;
			}

			public override string ToString()
			{
				string res = "{" + NodeType.Name + "}, PREC " + PrecedenceLevel;

				if (IsRightAssociative)
				{
					res += " [Right]";
				}

				return res;
			}
		}
	}
}
