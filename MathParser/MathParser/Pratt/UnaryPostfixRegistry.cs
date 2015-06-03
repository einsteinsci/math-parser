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
		static Dictionary<TokenClass, RegItem> registry =
			new Dictionary<TokenClass, RegItem>();

		public static void Register(TokenClass token, Type nodeType, 
			int precedence)
		{
			Type _nodeTypeOperatorUnary = typeof(NodeOperatorBinary);

			if (!_nodeTypeOperatorUnary.IsAssignableFrom(nodeType))
			{
				throw new InvalidCastException(
					"Cannot register unary postfix operator without unary node.");
			}

			RegItem reg = new RegItem(nodeType, precedence);

			if (registry.ContainsKey(token))
			{
				Logger.Log(LogLevel.Warning, Logger.OPERATOR_REGISTRY,
					"Key for " + token.ToString() + " already exists. Replacing with type " +
					nodeType.ToString() + ".");

				registry[token] = reg;
			}
			else
			{
				registry.Add(token, reg);
			}
		}

		public sealed class RegItem
		{
			public Type NodeType
			{ get; private set; }

			public int PrecedenceLevel
			{ get; private set; }

			public RegItem(Type nodeType, int precedence)
			{
				NodeType = nodeType;
				PrecedenceLevel = precedence;
			}

			public override string ToString()
			{
				return "{" + NodeType.Name + "}, PREC " + PrecedenceLevel;
			}
		}
	}
}
