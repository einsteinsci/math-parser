using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace MathParser
{
	/// <summary>
	/// Provides options for the extension of this library
	/// </summary>
	public static class Extensibility
	{
		/// <summary>
		/// List of assemblies used in the extension of this library.
		/// Add your assembly to this list for it to extend this library.
		/// </summary>
		public static List<Assembly> LoadedExtensions
		{ get; private set; }

		/// <summary>
		/// List of all assemblies loaded by this library, including itself.
		/// </summary>
		public static List<Assembly> AllAssemblies
		{
			get
			{
				List<Assembly> res = new List<Assembly>(LoadedExtensions);
				res.Insert(0, Assembly.GetAssembly(typeof(Extensibility)));

				return res;
			}
		}

		static Extensibility()
		{
			LoadedExtensions = new List<Assembly>();
		}

		/// <summary>
		/// Adds all assemblies in a folder to LoadedExtensions.
		/// </summary>
		/// <param name="folderPath">Full path of folder to load from</param>
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

		internal static List<Type> GetAllTypesWithAttribute(Type attType)
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

		internal static List<Type> GetAllTypesWithAttribute<AttType>()
		{
			return GetAllTypesWithAttribute(typeof(AttType));
		}
	}
}
