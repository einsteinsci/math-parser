using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathPlusLib;
using System.Reflection;
using MathParser.ParseTree;
using System.Linq.Expressions;
using MathParser.Types;

namespace MathParser.Functions
{
	/// <summary>
	/// Stores all functions used in 
	/// </summary>
	public static class FunctionRegistry
	{
		private static Dictionary<string, FunctionInfo> registry;

		private static bool hasInitialized = false;
		private static bool isInitializing = false;

		/// <summary>
		/// Gets a loaded function from the registry by name.
		/// </summary>
		/// <param name="name">Name of function to get</param>
		/// <returns>Function with the corresponding name</returns>
		public static FunctionInfo GetFunction(string name)
		{
			Init();

			if (registry.ContainsKey(name))
			{
				return registry[name];
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Initializes the Function registry
		/// </summary>
		/// <param name="force"></param>
		public static void Init(bool force = false)
		{
			if (isInitializing)
			{
				return;
			}

			isInitializing = true;

			if (hasInitialized && !force)
			{
				return;
			}

			registry = new Dictionary<string, FunctionInfo>();
			foreach (Assembly assembly in Extensibility.AllAssemblies)
			{
				Logger.Log(LogLevel.Info, Logger.REGISTRY, 
					"Starting function registry for assembly " + assembly.GetName().Name);
				
				foreach (Type type in assembly.GetTypes())
				{
					IEnumerable<FunctionLibraryAttribute> libatts =
						type.GetCustomAttributes<FunctionLibraryAttribute>();

					if (libatts == null || libatts.Count() == 0)
					{
						continue;
					}

					LoadFromMethods(type);
					LoadFromProperties(type);
					LoadFromFields(type);
				}
			}

			isInitializing = false;
			hasInitialized = true;
		}
		
		private static void LoadFromFields(Type type)
		{
			FieldInfo[] fields = type.GetFields();

			foreach (FieldInfo f in fields)
			{
				if (!f.IsStatic)
				{
					continue;
				}

				MathFunctionAttribute mfatt = f.GetCustomAttribute<MathFunctionAttribute>();

				if (f.FieldType != typeof(FunctionInfo))
				{
					Logger.Log(LogLevel.Warning, Logger.REGISTRY,
						"MathFunctionAttribute applied to field that is " +
						"not a FunctionInfo. Ignoring.");
					continue;
				}

				FunctionInfo func = f.GetValue(null) as FunctionInfo;

				if (func == null)
				{
					continue;
				}

				Logger.Log(LogLevel.Debug, Logger.REGISTRY, "Registering function: " + func.Name);
				RegisterFunction(func);
			}
		}

		private static void LoadFromProperties(Type type)
		{
			PropertyInfo[] properties = type.GetProperties();

			foreach (PropertyInfo prop in properties)
			{
				MathFunctionAttribute mfatt = prop.
					GetCustomAttribute<MathFunctionAttribute>();

				if (mfatt == null)
				{
					continue;
				}

				if (prop.PropertyType != typeof(FunctionInfo))
				{
					Logger.Log(LogLevel.Warning, Logger.REGISTRY,
						"MathFunctionAttribute applied to property that is " +
						"not a FunctionInfo. Ignoring.");
					continue;
				}

				MethodInfo getter = prop.GetGetMethod(true);
				FunctionInfo func = getter.Invoke(null, new object[0]) as FunctionInfo;

				if (func == null)
				{
					continue;
				}

				Logger.Log(LogLevel.Debug, Logger.REGISTRY, "Registering function: " + func.Name);
				RegisterFunction(func);
			}
		}
		
		private static void LoadFromMethods(Type type)
		{
			MethodInfo[] methods = type.GetMethods();

			foreach (MethodInfo method in methods)
			{
				MathFunctionAttribute mfatt = method.
					GetCustomAttribute<MathFunctionAttribute>();

				if (!method.IsStatic)
				{
					continue;
				}

				if (mfatt == null)
				{
					continue;
				}

				Delegate del = CreateDelegate(method);

				MathType ret = MathType.Boolean;
				try
				{
					ret = method.ReturnType.ToMathType();
				}
				catch (ArgumentException)
				{
					continue;
				}

				List<MathType> args = new List<MathType>();
				bool discard = false;
				foreach (ParameterInfo p in method.GetParameters())
				{
					try
					{
						args.Add(p.ParameterType.ToMathType());
					}
					catch (ArgumentException)
					{
						discard = true;
						break;
					}
				}

				if (discard)
				{
					Logger.Log(LogLevel.Warning, Logger.REGISTRY,
						"Argument found to be invalid for method " + method.Name +
						"(). Ignoring.");
					continue;
				}

				FunctionInfo func = new FunctionInfo(del, ret, mfatt.Name, args.ToArray());

				Logger.Log(LogLevel.Debug, Logger.REGISTRY, "Registering function: " + func.Name);
				RegisterFunction(func);
			}
		}

		/// <summary>
		/// Loads a FunctionInfo into the registry
		/// </summary>
		/// <param name="function">FunctionInfo to load</param>
		public static void RegisterFunction(FunctionInfo function)
		{
			Init(false);

			if (registry.ContainsKey(function.Name))
			{
				Logger.Log(LogLevel.Warning, Logger.REGISTRY, "Function " + function.Name +
					" already registered. Replacing.");
				registry[function.Name] = function;
			}
			else
			{
				registry.Add(function.Name, function);
			}
		}

		// Handy
		private static Delegate CreateDelegate(MethodInfo info)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info"); // would use nameof, but that's .NET 5
			}

			if (!info.IsStatic)
			{
				throw new ArgumentException("info cannot be null.");
			}

			List<Type> argTypes = new List<Type>();
			foreach (ParameterInfo arg in info.GetParameters())
			{
				argTypes.Add(arg.ParameterType);
			}
			argTypes.Add(info.ReturnType);

			Type delType = Expression.GetDelegateType(argTypes.ToArray());

			return Delegate.CreateDelegate(delType, info);
		}
	}
}
