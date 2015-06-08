using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Lexing;

namespace MathParser.Parsing
{
	public static class UnaryPrefixRegistry
	{
		static Dictionary<TokenType, Type> registry = 
			new Dictionary<TokenType, Type>();

		static UnaryPrefixRegistry()
		{
			Init();
		}

		public static void Init()
		{
			List<Type> prefixes = Extensibility.
				GetAllTypesWithAttribute<PrefixOperatorAttribute>();

			foreach (Type t in prefixes)
			{
				object obj = t.GetCustomAttributes(typeof(PrefixOperatorAttribute),
					false).FirstOrDefault();
				PrefixOperatorAttribute att = obj as PrefixOperatorAttribute;

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
			Type _nodeOperatorUnary = typeof(NodeOperatorUnary);
			if (!_nodeOperatorUnary.IsAssignableFrom(nodeType))
			{
				throw new InvalidCastException(
					"Cannot register unary prefix operator without unary node.");
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

		public static List<TokenType> GetTokens()
		{
			return registry.Keys.ToList();
		}
	}
}
