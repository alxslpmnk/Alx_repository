using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethods;
using OOP_Lab_4;

namespace ExtensionMethods
{
	internal static class MyExtensns
	{
		public static int Count(this Stack x)
		{
			return x.last;
		}
		public static float Average(this Stack x)
		{
			float s;
			s = x.last / 2;
			return s;
		}
	}
}

namespace OOP_Lab_4
{


	class Stack
	{
		public int[] Value;
		public int rz;
		internal int last = 0;

		public Stack(int size)
		{
			Value = new int[size];
			rz = size;
		}
		public void Push(int x)
		{
			if (last <= rz)
			{
				Value[last] = x;
				last++;
			}
			else Console.WriteLine("error");
		}
		public void Pop()
		{
			if (last != 0)
			{
				Console.WriteLine(Value[last - 1]);
				last--;
			}
		}
		public bool Empty()
		{

			if (last == 0)
			{
				Console.WriteLine("Стек пустой");
				return true;
			}
			else return false;
		}


		public static Stack operator +(Stack x, int y)
		{
			x.Push(y);
			return new Stack(x.rz) { };
		}
		public static Stack operator --(Stack x)
		{
			Console.WriteLine(x.Value[x.last-1]);
			x.last= x.last - 1;
			return new Stack(x.rz);
		}
		public static bool operator true(Stack x)
		{
			if (x.last == 0)
			{
				Console.WriteLine("Стек пустой");
			}

			return true;
		}
		public static bool operator false(Stack x)
		{
			if (x.last != 0)
			{
				Console.WriteLine("Стек не пустой");
			}

			return false;
		}
		public static Stack operator >(Stack x, Stack x1)
		{
			int[] sort = new int[x.last];
			for (int i = 0; i < x.last; i++)
			{
				sort[i] = x.Value[i];
			}
			Array.Sort(sort);
			for (int i = 0; i < x.last; i++)
			{
				x1.Push(sort[i]);
			}

			return new Stack(10);
		}
		public static Stack operator <(Stack x, Stack x1)
		{
			int[] sort = new int[x1.last];
			for (int i = 0; i < x1.last; i++)
			{
				sort[i] = x1.Value[i];
			}
			Array.Sort(sort);
			for (int i = 0; i < x1.last; i++)
			{
				x.Push(sort[i]);
			}

			return new Stack(10);

		}



		class Program
		{
			static void Main(string[] args)
			{
				Stack m1 = new Stack(10);
				int y = 134, y1 = 12;
				Stack m5 = new Stack(10);
				Stack m2 = m1 + y;
				Stack m3 = m1 + y1;
				m1.Push(1); m1.Push(2);
				m1=m1--;
				bool emp = (m2.Empty() == false) ?  true : false;
				Console.WriteLine("Элементов в стеке - " + m1.Count());
				Console.WriteLine("Средний элемент - " + m1.Average());
				Stack m4 = m1 > m5;
				for (int i = 0; i < m1.last; i++)
				{
					Console.WriteLine(m1.Value[i]);
				}
				Console.WriteLine(" ");
				for (int i = 0; i< m5.last;i++)
				{
					Console.WriteLine(m5.Value[i]);
				}
			}
		}
	}
}