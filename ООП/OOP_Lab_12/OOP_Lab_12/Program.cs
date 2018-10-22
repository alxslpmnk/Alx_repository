using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace OOP_Lab_12
{
	public class Sea : IComparable
	{
		public string name;

		public Sea(string str)
		{
			name = str;
		}

		public int CompareTo(object obj)
		{
			throw new NotImplementedException();
		}

		public int Compare(object obj1, object obj2)
		{
			Sea x1 = (Sea)obj1;
			Sea x2 = (Sea)obj2;
			if (x1.name.Length < x2.name.Length)
			{ return -1; }
			if (x1.name.Length > x2.name.Length)
			{ return 1; }
			if (x1.name.Length == x2.name.Length)
			{ return 0; }
			else return -2;
		}
		public  void Print(string str)
		{
			Console.WriteLine(str + "hello");
		}

	}

	public class Reflector
	{
		public void AllinFile(Type type)
		{
			FileStream file1 = new FileStream("D:\\new_file.txt", FileMode.Create);
			StreamWriter writer = new StreamWriter(file1);
			writer.Write(type.GetMembers());
			writer.Close();
		}
		public void Methods(Type type)
		{foreach(MethodInfo m in type.GetMethods())
			Console.WriteLine(m.Name);
		}

		public void Information(Type type)
		{
			FieldInfo[] x = type.GetFields();
		    foreach(FieldInfo t in x)
			{
				Console.WriteLine(t.Name);
				Console.WriteLine(t.FieldType);
			}
			PropertyInfo[] x1 = type.GetProperties();
			foreach (PropertyInfo t in x1)
			{
				Console.WriteLine(t.Name);
				Console.WriteLine(t.PropertyType);
			}
		}
		public void Interfaces(Type type)
		{
			foreach (Type iType in type.GetInterfaces()) { Console.WriteLine(iType.Name); }
		}

		public void Methods_2(Type type)
		{
			MethodInfo[] x = type.GetMethods();
			foreach(MethodInfo m in x)
			{
				ParameterInfo[] par = m.GetParameters();
				foreach (ParameterInfo p in par) {
					if (p.ParameterType == typeof(string))
					{ Console.WriteLine(m.Name); }
				}
					}
		}

		public void FromFile(Type type, MethodInfo method)
		{
			FileStream fs = new FileStream("D:\\new_file2.txt", FileMode.Open);
			StreamReader str = new StreamReader(fs);
			MethodInfo x = type.GetMethod(method.Name);
			Sea s = new Sea("Pacific");
			string[] s1 = new string[1];
			s1[0]= (str.ReadToEnd());
			x.Invoke(s, s1);
			str.Close();
		}

	}
	class Program
	{
		static void Main(string[] args)
		{
			Reflector refl = new Reflector();
			refl.Methods(typeof(Sea));
			Console.WriteLine("________");
			refl.Methods(typeof(Stack<Sea>));
			Console.WriteLine("________");
			refl.AllinFile(typeof(Math));
			refl.Information(typeof(Sea));
			Console.WriteLine("________");
			refl.Information(typeof(Int32));
			Console.WriteLine("________");
			refl.Interfaces(typeof(Sea));
			Console.WriteLine("________");
			refl.Methods_2(typeof(Sea));
			Console.WriteLine("________");
			Type t = typeof(Sea);
			MethodInfo method = t.GetMethod("Print");
			refl.FromFile(typeof(Sea), method);
		}
	}
}
