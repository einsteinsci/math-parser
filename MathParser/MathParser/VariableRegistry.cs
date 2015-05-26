using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
	public sealed class VariableRegistry
	{
		public static VariableRegistry Global
		{ get { return _global; } }
		private static VariableRegistry _global = new VariableRegistry();

		public Dictionary<string, IResultValue> Registry
		{ get; private set; }

		public IResultValue this[string name]
		{
			get
			{
				if (Registry.ContainsKey(name))
				{
					return Registry[name];
				}
				else
				{
					return null;
				}
			}
			set
			{
				Registry[name] = value;
			}
		}

		public VariableRegistry()
		{
			Registry = new Dictionary<string, IResultValue>();
		}

		public static IResultValue Get(string varname)
		{
			return Global[varname];
		}
		public static void Set(string varname, IResultValue value)
		{
			Global[varname] = value;
		}

		public bool ContainsVariable(string varname)
		{
			return this[varname] != null;
		}

		public void Create(string varname, IResultValue initialValue)
		{
			Registry.Add(varname, initialValue);
		}
	}
}
