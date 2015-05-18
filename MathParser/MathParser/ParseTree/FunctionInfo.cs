using MathPlusLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.ParseTree
{
	public sealed class FunctionInfo
	{
		public MathType ReturnType
		{ get; private set; }

		public List<MathType> ArgumentTypes
		{ get; private set; }

		public int ArgumentCount
		{ get { return ArgumentTypes.Count; } }

		public string Name
		{ get; private set; }

		public Delegate Function
		{ get; private set; }

		public FunctionInfo(Delegate function, MathType ret, string name, params MathType[] args)
		{
			Function = function;
			ReturnType = ret;
			Name = name;
			ArgumentTypes = args.ToList();
		}

		public FunctionInfo(Delegate function)
		{
			Function = function;

			Type ret = function.Method.ReturnType;
			if (ret == typeof(double))
			{
				ReturnType = MathType.Number;
			}
			else if (ret == typeof(string))
			{
				ReturnType = MathType.String;
			}
			else if (ret == typeof(MathMatrix))
			{
				ReturnType = MathType.Matrix;
			}
			else
			{
				throw new ArgumentException("Return type is of invalid type: " + ret.ToString());
			}

			ParameterInfo[] args = function.Method.GetParameters();
			ArgumentTypes = new List<MathType>();
			foreach (ParameterInfo arg in args)
			{
				Type t = arg.GetType();
				if (t == typeof(double))
				{
					ArgumentTypes.Add(MathType.Number);
				}
				else if (t == typeof(string))
				{
					ArgumentTypes.Add(MathType.String);
				}
				else if (t == typeof(MathMatrix))
				{
					ArgumentTypes.Add(MathType.Matrix);
				}
				else
				{
					throw new ArgumentException("Argument is of invalid type: " + t.ToString());
				}
			}
		}

		public ResultValue Invoke(params ResultValue[] args)
		{
			if (args.Length != ArgumentCount)
			{
				throw new TargetInvocationException(
					"Argument count mismatched. Needs " + 
					ArgumentCount.ToString() + ", got " + 
					args.Length, null);
			}

			object[] argvals = new object[ArgumentCount];
			for (int i = 0; i < ArgumentCount; i++)
			{
				switch (args[i].Type)
				{
				case MathType.Number:
					argvals[i] = args[i].ToDouble();
					continue;
				case MathType.String:
					argvals[i] = args[i].ToString();
					continue;
				case MathType.Matrix:
					argvals[i] = args[i].ToMatrix();
					continue;
				default:
					throw new ArgumentOutOfRangeException(
						"Argument is of invalid MathType: " + 
						args[i].Type.ToString());
				}
			}

			//object res =  // HERE
		}
	}
}
