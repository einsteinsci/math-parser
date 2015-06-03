using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Tokens;

namespace MathParser.Pratt
{
	public static class UnaryPrefixRegistry
	{
		static Dictionary<TokenClass, Type> registry = 
			new Dictionary<TokenClass, Type>();

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
					Logger.Log(LogLevel.Error, Logger.OPERATOR_REGISTRY,
						"Attribute is null!");

					System.Diagnostics.Debugger.Break();
				}

				Register(att.TokenInstance, att.NodeType);
			}

			//Register(TokenClass.OperatorNot, typeof(NodeOperatorNot));
			//Register(TokenClass.OperatorMinus, typeof(NodeOperatorNegative));
			//Register(TokenClass.OperatorNegative, typeof(NodeOperatorNegative));
		}

		public static void Register(TokenClass token, Type nodeType)
		{
			Type _nodeOperatorUnary = typeof(NodeOperatorUnary);
			if (!_nodeOperatorUnary.IsAssignableFrom(nodeType))
			{
				throw new InvalidCastException(
					"Cannot register unary prefix operator without unary node.");
			}

			if (registry.ContainsKey(token))
			{
				Logger.Log(LogLevel.Warning, Logger.OPERATOR_REGISTRY,
					"Key for " + token.ToString() + " already exists. Replacing with type " +
					nodeType.ToString() + ".");
				registry[token] = nodeType;
			}
			else
			{
				registry.Add(token, nodeType);
			}
		}

		public static NodeOperatorUnary MakeNode(TokenClass token, NodeFactor operand)
		{
			if (!registry.ContainsKey(token))
			{
				throw new ArgumentOutOfRangeException(
					"Cannot make unregistered node.");
			}

			Type nodeType = registry[token];

			object obj = Activator.CreateInstance(nodeType, operand);

			return obj as NodeOperatorUnary;
		}

		public static List<TokenClass> GetTokens()
		{
			return registry.Keys.ToList();
		}
	}
}
