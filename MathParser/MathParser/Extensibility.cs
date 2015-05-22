using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

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
	}
}
