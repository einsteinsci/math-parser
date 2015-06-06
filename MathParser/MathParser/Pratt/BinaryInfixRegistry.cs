using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.ParseTree;
using MathParser.Tokens;

namespace MathParser.Pratt
{
	public static class BinaryInfixRegistry
	{
		static Dictionary<TokenClass, RegItem> registry =
			new Dictionary<TokenClass, RegItem>();

		static BinaryInfixRegistry()
		{
			Init();
		}

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

		public static void Register(TokenClass token, Type nodeType, 
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

		public static NodeOperatorBinary MakeNode(TokenClass token, 
			NodeFactor left, NodeFactor right)
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

		public static RegItem Get(TokenClass key)
		{
			return registry[key];
		}

		public static List<TokenClass> GetTokens()
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
