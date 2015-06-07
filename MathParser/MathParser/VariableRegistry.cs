using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser.Lexing;
using MathParser.Types;

namespace MathParser
{
	/// <summary>
	/// Registry where all variables are stored.
	/// </summary>
	public sealed class VariableRegistry
	{
		/// <summary>
		/// Singleton instance of registry
		/// </summary>
		public static VariableRegistry Instance
		{ get { return _instance; } }
		private static VariableRegistry _instance = new VariableRegistry();

		/// <summary>
		/// Inner registry of variables
		/// </summary>
		public Dictionary<string, IResultValue> Registry
		{ get; private set; }

		/// <summary>
		/// Gets the value stored in a variable
		/// </summary>
		/// <param name="name">Variable name</param>
		/// <returns>The value stored in the specified variable</returns>
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

		/// <summary>
		/// Instantiates a VariableRegistry
		/// </summary>
		public VariableRegistry()
		{
			Registry = new Dictionary<string, IResultValue>();
		}

		/// <summary>
		/// Gets the value stored in a variable
		/// </summary>
		/// <param name="varname">Variable name</param>
		/// <returns>
		///   Value stored in the specified variable, 
		///   null if variable does not exist.
		/// </returns>
		public static IResultValue Get(string varname)
		{
			return Instance[varname];
		}

		/// <summary>
		/// Sets a variable to a value
		/// </summary>
		/// <param name="varname">Variable name</param>
		/// <param name="value">Value to set variable to</param>
		public static void Set(string varname, IResultValue value)
		{
			if (ContainsVariable(varname))
			{
				Instance[varname] = value;
			}
			else
			{
				Logger.Log(LogLevel.Error, "variable",
					"Variable " + varname + " does not exist.");
			}
		}

		/// <summary>
		/// Returns whether a variable exists in the registry.
		/// </summary>
		/// <param name="varname">Variable to check for</param>
		/// <returns>True if the variable exists, false if not</returns>
		public static bool ContainsVariable(string varname)
		{
			return Instance[varname] != null;
		}

		/// <summary>
		/// Creates a variable within the registry.
		/// </summary>
		/// <param name="varname">Name of variable to create.</param>
		/// <param name="initialValue">Value and type to initialize to</param>
		public static void Create(string varname, IResultValue initialValue)
		{
			if (!ContainsVariable(varname))
			{
				Instance.Registry.Add(varname, initialValue);
			}
			else
			{
				Logger.Log(LogLevel.Warning, "variable",
					"Variable " + varname + " already exists.");
			}
		}
	}
}
