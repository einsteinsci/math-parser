using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace MathParser
{
	public static class Extensibility
	{
		public static List<Assembly> LoadedExtensions
		{ get; private set; }

		public static List<Assembly> AllAssemblies
		{
			get
			{
				List<Assembly> res = new List<Assembly>(LoadedExtensions);
				res.Add(Assembly.GetCallingAssembly());

				return res;
			}
		}

		static Extensibility()
		{
			LoadedExtensions = new List<Assembly>();
		}

		public static void AddAllAssembliesInPath(string folderPath)
		{
			DirectoryInfo di = new DirectoryInfo(folderPath);
			FileInfo[] files = di.GetFiles("*", SearchOption.TopDirectoryOnly);

			foreach (FileInfo file in files)
			{
				try
				{
					Assembly assem = Assembly.LoadFile(file.FullName);
					LoadedExtensions.Add(assem);
				}
				catch (FileLoadException)
				{
					continue;
				}
				catch (FileNotFoundException)
				{
					continue;
				}
				catch (BadImageFormatException)
				{
					continue;
				}
			}
		}

		public static List<Type> GetAllTypesWithAttribute(Type attType)
		{
			List<Type> res = new List<Type>();

			foreach (Assembly asm in AllAssemblies)
			{
				foreach (Type t in asm.GetTypes())
				{
					if (t.GetCustomAttribute(attType) != null)
					{
						res.Add(t);
					}
				}
			}

			return res;
		}

		public static List<Type> GetAllTypesWithAttribute<AttType>()
		{
			return GetAllTypesWithAttribute(typeof(AttType));
		}

		public static List<Type> GetAllTypesWithAttribute(Attribute attInstance)
		{
			return GetAllTypesWithAttribute(attInstance.GetType());
		}
	}
}
