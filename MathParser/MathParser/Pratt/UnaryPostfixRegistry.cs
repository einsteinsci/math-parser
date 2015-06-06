using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Tokens;

namespace MathParser.Pratt
{
	public static class UnaryPostfixRegistry
	{
		static Dictionary<TokenType, Type> registry =
			new Dictionary<TokenType, Type>();

		static UnaryPostfixRegistry()
		{
			Init();
		}

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

		public static NodeOperatorUnary MakeNode(TokenType token, NodeFactor left)
		{
			if (!registry.ContainsKey(token))
			{
				throw new ArgumentOutOfRangeException(
					"Token not found in registry.");
			}

			Type nodeType = registry[token];

			object obj = Activator.CreateInstance(nodeType, left);

			return obj as NodeOperatorUnary;
		}

		public static Type Get(TokenType tokenClass)
		{
			return registry[tokenClass];
		}

		public static List<TokenType> GetTokens()
		{
			return registry.Keys.ToList();
		}
	}
}
