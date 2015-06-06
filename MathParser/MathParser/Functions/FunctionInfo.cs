using MathPlusLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MathParser.Types;

namespace MathParser.Functions
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
			if (ret == typeof(double) || ret == typeof(float))
			{
				ReturnType = MathType.Real;
			}
			else if (ret == typeof(long) || ret == typeof(int) || ret == typeof(short))
			{
				ReturnType = MathType.Integer;
			}
			else if (ret == typeof(string))
			{
				ReturnType = MathType.String;
			}
			else if (ret == typeof(bool))
			{
				ReturnType = MathType.Boolean;
			}
			else if (ret == typeof(List<double>) || ret == typeof(double[]) ||
				ret == typeof(List<float>) || ret == typeof(float[]))
			{
				ReturnType = MathType.List;
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
				if (t == typeof(double) || t == typeof(float))
				{
					ArgumentTypes.Add(MathType.Real);
				}
				else if (t == typeof(long) || t == typeof(int) || t == typeof(short))
				{
					ArgumentTypes.Add(MathType.Integer);
				}
				else if (t == typeof(string))
				{
					ArgumentTypes.Add(MathType.String);
				}
				else if (t == typeof(bool))
				{
					ArgumentTypes.Add(MathType.Boolean);
				}
				else if (ret == typeof(List<double>) || ret == typeof(double[]) ||
					ret == typeof(List<float>) || ret == typeof(float[]))
				{
					ArgumentTypes.Add(MathType.List);
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

		public IResultValue Invoke(params IResultValue[] args)
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
				case MathType.Real:
					argvals[i] = args[i].ToDouble();
					continue;
				case MathType.Integer:
					argvals[i] = args[i].ToInteger();
					continue;
				case MathType.String:
					argvals[i] = args[i].ToString();
					continue;
				case MathType.Boolean:
					argvals[i] = args[i].ToBoolean();
					continue;
				case MathType.List:
					argvals[i] = args[i].ToList();
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

			object res = Function.DynamicInvoke(argvals);
			if (res is double || res is float)
			{
				return new ResultNumberReal((double)res);
			}
			if (res is long || res is int || res is short)
			{
				return new ResultNumberInteger((long)res);
			}
			else if (res is string)
			{
				return new ResultString((string)res);
			}
			else if (res is bool)
			{
				return new ResultBoolean((bool)res);
			}
			else if (res is MathMatrix)
			{
				return null;
			}
			else
			{
				throw new NotSupportedException(
					"Return type is of invalid Type: " +
					res.GetType().ToString());
			}
		}

		public override string ToString()
		{
			string res = ReturnType.ToString() + " " + Name + "(";
			for (int i = 0; i < ArgumentCount; i++)
			{
				res += ArgumentTypes[i].ToString();

				if (i < ArgumentCount - 1)
				{
					res += ", ";
				}
			}

			return res + ")";
		}
	}
}
