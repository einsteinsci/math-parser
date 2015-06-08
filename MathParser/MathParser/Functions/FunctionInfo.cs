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
		/// <summary>
		/// Specifies what type the function returns
		/// </summary>
		public MathType ReturnType
		{ get; private set; }

		/// <summary>
		/// List of the types for each argument
		/// </summary>
		public List<MathType> ArgumentTypes
		{ get; private set; }

		/// <summary>
		/// Number of arguments in the function
		/// </summary>
		public int ArgumentCount
		{ get { return ArgumentTypes.Count; } }

		/// <summary>
		/// Name of the function
		/// </summary>
		public string Name
		{ get; private set; }

		/// <summary>
		/// Functional type to run for the function
		/// </summary>
		public Delegate Function
		{ get; private set; }

		/// <summary>
		/// Instantiates a new FunctionInfo
		/// </summary>
		public FunctionInfo(Delegate function, MathType ret, string name, params MathType[] args)
		{
			Function = function;
			ReturnType = ret;
			Name = name;
			ArgumentTypes = args.ToList();
		}

		/// <summary>
		/// Instantiates a new FunctionInfo
		/// </summary>
		public FunctionInfo(Delegate function)
		{
			Function = function;

			Type ret = function.Method.ReturnType;
			ReturnType = ret.ToMathType();
			
			ParameterInfo[] args = function.Method.GetParameters();
			ArgumentTypes = new List<MathType>();
			foreach (ParameterInfo arg in args)
			{
				Type t = arg.GetType();
				ArgumentTypes.Add(t.ToMathType());
			}
		}

		/// <summary>
		/// Runs the code in the function, given the required arguments.
		/// </summary>
		/// <param name="args">Arguments used by function</param>
		/// <returns>The return value once the function completes</returns>
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
				argvals[i] = args[i].CoreValue;
			}

			object res = Function.DynamicInvoke(argvals);
			if (res is double || res is float)
			{
				return new ResultNumberReal(Convert.ToDouble(res));
			}
			if (res is long || res is int || res is short)
			{
				return new ResultNumberInteger(Convert.ToInt64(res));
			}
			else if (res is string)
			{
				return new ResultString(res as string);
			}
			else if (res is bool)
			{
				return new ResultBoolean(Convert.ToBoolean(res));
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
		
		/// <summary>
		/// Converts the function to a C-style function declaration
		/// </summary>
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
