using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_2
{
    class Program
    {
		static void Main(string[] args)
		{
			var mas = new[] { 2, 5, 4, 3 };
			sbyte a = 1;
			short b = 2;
			int c = 20;
			long d = 1;
			byte e = 4;
			ushort f = 16;
			uint g = 1;
			ulong h = 1;
			char i = 'i';
			bool j = false;
			float k = 122;
			double l = 1;
			decimal m = 1;
			string o = "asf";
			object p = 1;
			c = a;
			d = b;
			g = e;
			h = f;
			l = k;
			p = (decimal)m;
			c = (byte)e;
			int a1 = 4;
			float a2 = (int)a1;
			byte a3 = 12;
			short a4 = (byte)a3;
			byte a5 = 220;
			float a6 = (byte)a5;
			Int32 b1 = 5;
			Object b2 = b1;
			byte b3 = (byte)(int)b1;
			Console.WriteLine(mas);
			int? n1 = null;
			int? n2 = null;
			
			string s1 = "goodbye";
			string s2 = "hello, world";
			if (s1 == s2) Console.WriteLine("Стркои равны");
			else Console.WriteLine("Строки не равны");
			string s3 = "sdqdqefqfq";
			s1 = s1 + s2;
			String.Copy(s1);
			string s4 = s1.Substring(3, 3);
			char[] delims = ".,;:!?\n\xD\xA\" ".ToCharArray();
			string[] words = s2.Split(delims, StringSplitOptions.RemoveEmptyEntries);
			foreach (string word in words)
				Console.WriteLine(word);
			foreach (string word in words)
				if (word[word.Length - 1] == 's')
					Console.WriteLine(word);
			s2.Insert(2, s4);
			s2.Remove(3);
			string s6 = "";// Пустая строка
			string s7 = null;// Строка null
			s6.Insert(0, s2);
			if (s6 == s7) Console.WriteLine("Стркои равны");
			else Console.WriteLine("Строки не равны");
			StringBuilder sb = new StringBuilder("sampletext", 50);
			sb.Remove(3, 4);
			sb.Append("qweqwe");
			sb.AppendFormat("rty");

			int[,] mass = { { 1, 2 }, { 3, 4 } };
			for (int i1 = 0; i1 <= 1; i1++)
			{ for (int j1 = 0; j1 <= 1; j1++) { Console.Write(mass[i1, j1] + ", "); }
				Console.Write("\n");
			}
			string[] mass1v =  new string[3];
			mass1v[0] = "1234";
			mass1v[1] = "qwerty";
			mass1v[2] = "hello, world";
			for (int i1 = 0; i1 < 3; i1++)
			{
				Console.WriteLine(mass1v[i1]);
			}
			Console.WriteLine("Длина массива - " + mass1v.Length);
			Console.WriteLine("Введите значение: ");
			string kp = Console.ReadLine();
			mass1v[0] = kp;

			int[][] mass2 = { new int[2], new int[3], new int[4] };
			foreach (int[] x in mass2) {
				
				foreach (int T in x)
				{
					Console.Write("\t" + T);
					Console.WriteLine();
				}
			}
			var mass4 = new int[] { 1, 2, 3 };
			var string1 = "ssss";

			ValueTuple<int, string, char, string, ulong> student = (1, "ss", '1', "sqwe", 123);
			Console.WriteLine(student);
			Console.WriteLine(student.Item1 + " " + student.Item3 + " " + student.Item4);
			var (l1, l2, l3, l4, l5) = student;
			ValueTuple<int, string, char, string, ulong> student1 = (15, "ss1", '4', "sqwe", 321);
			if (!Equals(student, student1))
			{ Console.WriteLine("Кортежи не равны"); }
			else Console.WriteLine("Кортежи равны");

			Tuple<double, double, double, char> local_function(double[] massiv, string temp)
			{
				double min, max,sum = 0;
				min = max = massiv[0];
				for (int step = 1; step < massiv.Length; step++)
				{
					sum = sum + massiv[step];
					if (massiv[step] < min)
						min = massiv[step];
					if (massiv[step] > max)
						max = massiv[step];
				}
				
			
				char ch = ((char)temp[0]);
				return Tuple.Create<double, double, double, char>(max, min, sum, ch);
			}
			double[] element1 = { 1, 5, 2, 4, 3, 7,9 };
			var new_tuple = local_function(element1, "sampletext");
			Console.WriteLine("MAX: " + new_tuple.Item1.ToString());
			Console.WriteLine("MIN: " + new_tuple.Item2.ToString());
			Console.WriteLine("SUM: " + new_tuple.Item3.ToString());
			Console.WriteLine("SYMBOL: " + new_tuple.Item4.ToString());
		}
		}
    }
