using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_11
{
	public class Point
	{
		public int x;
		public int y;
	}

	public class Triangle
	{

		public double max1 = 0, xx1 = 0, xx2 = 0;
		public static int count = 0;
		public Point t1;
		public Point t2;
		public Point t3;
		public double x1, x2, x3;
		static readonly long ID;
		public const int constanta = 12;
		public int l = 0;

		public void Coord()
		{
			Console.WriteLine("Первая точка треугольника - (" + t1.x + ", " + t1.y + ")");
			Console.WriteLine("Вторая точка треугольника - (" + t2.x + ", " + t2.y + ")");
			Console.WriteLine("Третья точка треугольника - (" + t3.x + ", " + t3.y + ")");
		}

		public void Sides()
		{
			x1 = Math.Sqrt(Math.Pow((t2.x - t1.x), 2) + Math.Pow((t2.y - t1.y), 2));
			x2 = Math.Sqrt(Math.Pow((t3.x - t2.x), 2) + Math.Pow((t2.y - t3.y), 2));
			x3 = Math.Sqrt(Math.Pow((t3.x - t1.x), 2) + Math.Pow((t3.y - t1.y), 2));
		}

		public static void DrawInfo(Triangle Obj)
		{
			Console.WriteLine("t1 ({0}, {1}) , t2 ({2}, {3}), t3 ({4}, {5})", Obj.t1.x, Obj.t1.y,
				Obj.t2.x, Obj.t2.y,
				Obj.t3.x, Obj.t3.y);
		}


		public double Perimeter()
		{
			return x1 + x2 + x3;
		}

		static Triangle()                        // Статический конструктор, высызвается 1 раз
		{
			count++;
			ID = DateTime.Now.Ticks;
		}

		public Triangle()
		{
			count++;
			t1 = new Point();
			t2 = new Point();
			t3 = new Point();
		}

		private Triangle(int x1 = 1, int y1 = 1)
		{
			count++;
			this.t1.x = x1;
			this.t1.y = y1;
			this.t2.x = x1;
			this.t2.y = y1;
			this.t3.x = x1;
			this.t3.y = y1;
		}

		public Triangle(Point x1, Point x2, Point x3)
		{
			count++;
			t1 = x1;
			t2 = x2;
			t3 = x3;
		}
		public void Possible()
		{
			if (x1 > x2 && x1 > x3)
			{ max1 = x1; xx1 = x2; xx2 = x3; }
			if (x2 > x1 && x2 > x3)
			{ max1 = x2; xx1 = x1; xx2 = x3; }
			if (x3 > x2 && x3 > x1)
			{ max1 = x3; xx1 = x1; xx2 = x2; }
		}

	}
	class Program
	{
		static void Main(string[] args)
		{
			string[] month = new string[] {"January", "February", "March", "April", "May", "June",
			"July","August","September","October","November","December"};
			IEnumerable<string> result = from n in month
										 where n.Length == 7
										 select n;
			foreach (string n in result)
			{ Console.Write(n + " "); }
			Console.WriteLine("");
			IEnumerable<string> result2 = from n in month
										  where n == "December" || n == "January" || n == "February" ||
				n == "June" || n == "July" || n == "August"
										  select n;
			foreach (string n in result2)
			{ Console.Write(n + " "); }
			Console.WriteLine("");

			IEnumerable<string> result3 = month.OrderBy(s => s);
			foreach (string n in result3)
			{ Console.Write(n + " "); }

			IEnumerable<string> result4 = from n in month
										  where n.Contains("u") && n.Length >= 4
										  select n;
			Console.WriteLine("");
			foreach (string n in result4)
			{ Console.Write(n + " "); }
			Console.WriteLine("");
			List<Triangle> tr = new List<Triangle>();
			tr.Add(new Triangle(new Point { x = 0, y = 0 }, new Point { x = 5, y = 5 }, new Point { x = 10, y = 0 }));
			tr.Add(new Triangle(new Point { x = 0, y = 0 }, new Point { x = 5, y = 5 }, new Point { x = 10, y = 0 }));
			tr.Add(new Triangle(new Point { x = 1, y = 1 }, new Point { x = 7, y = 4 }, new Point { x = 12, y = -4 }));
			tr.Add(new Triangle(new Point { x = 2, y = 3 }, new Point { x = 12, y = 7 }, new Point { x = 25, y = 5 }));
			tr.Add(new Triangle(new Point { x = 1, y = -1 }, new Point { x = 5, y = 10 }, new Point { x = 14, y = -1 }));
			tr.Add(new Triangle(new Point { x = 0, y = 0 }, new Point { x = 0, y = 8 }, new Point { x = 6, y = 0 }));
			tr.Add(new Triangle(new Point { x = 0, y = 0 }, new Point { x = 4, y = 7 }, new Point { x = 8, y = 0 }));
			foreach (Triangle el in tr)
			{
				el.Sides();
				el.Possible();
				if ((Math.Pow(el.xx1, 2) + Math.Pow(el.xx2, 2)) == Math.Pow(el.max1, 2))
				{
					el.l = 3;
					if (el.x1 == el.x2 || el.x1 == el.x3 || el.x2 == el.x3)
					{
						el.l = 1;
					}
				}
				else
				{
					if (el.x1 == el.x2 || el.x1 == el.x3 || el.x2 == el.x3)
					{
						el.l = 1;
						if ((int)el.x1 == (int)el.x2 && (int)el.x1 == (int)el.x3 && (int)el.x2 == (int)el.x3)
						{
							el.l = 2;
						}
					}
					else
					{
						el.l = 4;
					}
				}
			}

			IEnumerable<Triangle> z1_1 = from n in tr
										 where n.l == 1
										 select n;
			IEnumerable<Triangle> z1_2 = from n in tr
										 where n.l == 2
										 select n;
			IEnumerable<Triangle> z1_3 = from n in tr
										 where n.l == 3
										 select n;
			IEnumerable<Triangle> z1_4 = from n in tr
										 where n.l == 4
										 select n;

			double z2_1 = z1_1.Max(n => n.Perimeter());
			Console.WriteLine("Равнобедренный с наибольшим периметром - " + z2_1);
			z2_1 = z1_1.Min(n => n.Perimeter());
			Console.WriteLine("Равнобедренный с наименьшим периметром - " + z2_1);
			if (z1_2.Count() != 0)
			{
				double z2_2 = z1_2.Max(n => n.Perimeter());
				Console.WriteLine("Равносторонний с наибольшим периметром - " + z2_2);
				z2_2 = z1_2.Min(n => n.Perimeter());
				Console.WriteLine("Равносторонний с наименьшим периметром - " + z2_2);
			}
			double z2_3 = z1_3.Max(n => n.Perimeter());

			Console.WriteLine("Прямоугольный с наибольшим периметром - " + z2_3);
			z2_3 = z1_3.Min(n => n.Perimeter());
			Console.WriteLine("Прямоугольный с наименьшим периметром - " + z2_3);
			double z2_4 = z1_4.Max(n => n.Perimeter());
			Console.WriteLine("Произвольный с наибольшим периметром - " + z2_4);
			z2_4 = z1_4.Min(n => n.Perimeter());
			Console.WriteLine("Произвольный с наименьшим периметром - " + z2_4);

			double z3 = tr.Min(n => n.Perimeter());
			Console.WriteLine("Минимальная площадь - " + z3);

			int n1 = 20; int m1 = 3;
			IEnumerable<Triangle> z4 = from n in tr
									   where n.x1 < n1 && n.x1 > m1 && n.x2 < n1 && n.x2 > m1 && n.x3 < n1 && n.x3 > m1
									   select n;
			foreach (Triangle el in z4)
			{ Console.WriteLine(el.x1 + " " + el.x2 + " " + el.x3); }

			Array z5 = tr.OrderBy(n => n.Perimeter()).ToArray();
			foreach(Triangle el in z5)
			{ Console.WriteLine(el.Perimeter()); }
		}
	}
}