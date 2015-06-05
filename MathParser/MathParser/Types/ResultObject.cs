using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Types
{
	public abstract class ResultObject : IResultValue
	{
		public virtual object CoreValue
		{ get; protected set; }
	}
}
