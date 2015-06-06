using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathPlusLib;
using System.Reflection;
using MathParser.ParseTree;

namespace MathParser.Functions
{
	public static class Functions
	{
		public static List<FunctionInfo> AllFunctions
		{ get; private set; }

		public static bool HasRegistered
		{ get; private set; }

		public static FunctionInfo GetFunction(string name)
		{
			foreach (FunctionInfo inf in AllFunctions)
			{
				if (inf.Name.ToLower() == name.ToLower())
				{
					return inf;
				}
			}

			return null;
		}

		static Functions()
		{
			Init();
		}

		public static void Init(bool force = false)
		{
			if (HasRegistered && !force)
			{
				return;
			}

			AllFunctions = new List<FunctionInfo>();
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

					PropertyInfo[] properties = type.GetProperties();
					FieldInfo[] fields = type.GetFields();

					foreach (PropertyInfo prop in properties)
					{
						IEnumerable<Attribute> atts = prop.GetCustomAttributes<FunctionAttribute>();
						if (atts == null || atts.Count() == 0)
						{
							continue;
						}
						MethodInfo getter = prop.GetGetMethod(true);
						FunctionInfo func = getter.Invoke(null, new object[0]) as FunctionInfo;

						Logger.Log(LogLevel.Debug, Logger.REGISTRY, "Registering function: " + func.Name);
						AllFunctions.Add(func);
					}

					foreach (FieldInfo f in fields)
					{
						if (!f.IsStatic)
						{
							continue;
						}

						IEnumerable<Attribute> atts = f.GetCustomAttributes<FunctionAttribute>();
						if (atts == null || atts.Count() == 0)
						{
							continue;
						}

						FunctionInfo func = f.GetValue(null) as FunctionInfo;

						Logger.Log(LogLevel.Debug, Logger.REGISTRY, "Registering function: " + func.Name);
						AllFunctions.Add(func);
					}
				}
			}

			HasRegistered = true;
		}
	}
}
