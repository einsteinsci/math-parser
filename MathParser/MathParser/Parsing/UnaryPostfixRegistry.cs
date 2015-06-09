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
	/// Registry of all unary postfix operator parselets
	/// </summary>
	public static class UnaryPostfixRegistry
	{
		static Dictionary<TokenType, Type> registry =
			new Dictionary<TokenType, Type>();

		static UnaryPostfixRegistry()
		{
			Init();
		}

		/// <summary>
		/// Initialization code for the registry.
		/// </summary>
		public static void Init()
		{
			List<Type> prefixes = Extensibility.
				GetAllTypesWithAttribute<PostfixOperatorAttribute>();

			foreach (Type t in prefixes)
			{
				object obj = t.GetCustomAttributes(typeof(PostfixOperatorAttribute),
					false).FirstOrDefault();
				PostfixOperatorAttribute att = obj as PostfixOperatorAttribute;

				if (att == null)
				{
					Logger.Log(LogLevel.Error, Logger.REGISTRY,
						"Attribute is null!");

					System.Diagnostics.Debugger.Break();
				}

				Register(att.TokenInstance, att.NodeType);
			}
		}

		/// <summary>
		/// Registers a token to a node type
		/// </summary>
		/// <param name="token">Token to register</param>
		/// <param name="nodeType">
		///   Node type to register to. Must inherit from 
		///   NodeOperatorUnary.
		/// </param>
		public static void Register(TokenType token, Type nodeType)
		{
			Type _nodeTypeOperatorUnary = typeof(NodeOperatorUnary);

			if (!_nodeTypeOperatorUnary.IsAssignableFrom(nodeType))
			{
				throw new InvalidCastException(
					"Cannot register unary postfix operator without unary node.");
			}

			if (registry.ContainsKey(token))
			{
				Logger.Log(LogLevel.Warning, Logger.REGISTRY,
					"Key for " + token.ToString() + " already exists. Replacing with type " +
					nodeType.ToString() + ".");

				registry[token] = nodeType;
			}
			else
			{
				registry.Add(token, nodeType);
			}
		}

		/// <summary>
		/// Creates a node from a token type and operand
		/// </summary>
		/// <param name="token">Token type identifying the node</param>
		/// <param name="operand">Contents of the new node</param>
		/// <returns>A new node of the operator type</returns>
		public static NodeOperatorUnary MakeNode(TokenType token, NodeBase operand)
		{
			if (!registry.ContainsKey(token))
			{
				throw new ArgumentOutOfRangeException(
					"Token not found in registry.");
			}

			Type nodeType = registry[token];

			object obj = Activator.CreateInstance(nodeType, operand);

			return obj as NodeOperatorUnary;
		}

		/// <summary>
		/// Gets the type registered for a particular token type
		/// </summary>
		/// <param name="tokenType">Token type as the key in the registry</param>
		/// <returns>Node type stored for the specified TokenType</returns>
		public static Type Get(TokenType tokenType)
		{
			return registry[tokenType];
		}

		/// <summary>
		/// Gets all the token types stored in the registry.
		/// </summary>
		/// <returns>A list of all token types stored</returns>
		public static List<TokenType> GetTokens()
		{
			return registry.Keys.ToList();
		}
	}
}
