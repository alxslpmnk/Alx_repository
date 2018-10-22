using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP_Lab_3
{
	public class Point
	{
		public int x;
		public int y;
	}

	public class Triangle
	{
		public static int count = 0;
		public Point t1;
		public Point t2;
		public Point t3;
		public double x1, x2, x3;
		static readonly long ID;
		public const int constanta = 12;

		public void Coord()
		{
			Console.WriteLine("Первая точка треугольника - (" + t1.x + ", " + t1.y + ")");
			Console.WriteLine("Вторая точка треугольника - (" + t2.x + ", " + t2.y + ")");
			Console.WriteLine("Третья точка треугольника - (" + t3.x + ", " + t3.y + ")");
		}

		public void Sides()
		{
			x1 = Math.Sqrt(Math.Pow((t2.x - t1.x),2) + Math.Pow((t2.y - t1.y), 2));
			x2 = Math.Sqrt(Math.Pow((t3.x - t2.x), 2) + Math.Pow((t2.y - t3.y), 2));
			x3 = Math.Sqrt(Math.Pow((t3.x - t1.x), 2) + Math.Pow((t3.y - t1.y), 2));
		}

		public static void DrawInfo(Triangle Obj)
		{
			Console.WriteLine("t1 ({0}, {1}) , t2 ({2}, {3}), t3 ({4}, {5})", Obj.t1.x, Obj.t1.y,
				Obj.t2.x, Obj.t2.y,
				Obj.t3.x, Obj.t3.y);
		}
		public void Method(ref int i)
		{
			i = i + 44;
		}
		public void MethodOut(out int i)
		{
			i = 4;
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

		public override int GetHashCode()       // свой хэш
		{
			int unitCode;
			if (this.t1 == null)
				 unitCode = 1; 
			else unitCode = 2;
			return t2.x + unitCode;
		}


		public override bool Equals(System.Object obj)
		{
			if (obj == null)
			{
				return false;
			}

			Triangle p = obj as Triangle;
			if ((System.Object)p == null)
			{
				return false;
			}

			return (t1 == p.t1) && (t2 == p.t2) && (t3 == p.t3);
		}

		public static string ToString(System.Object obj)
		{
			if (obj == null)
			{
				return "nil";
			}

			Triangle p = obj as Triangle;
			if ((System.Object)p == null)
			{
				return "nil";
			}

			return p.t1.ToString() + ":" + p.t2.ToString() + ":" + p.t3.ToString();
		}
		public int Value
		{
			get
			{
				return Value;
			}
			set
			{
				if ((value > 0) && (value < 13))                // Тестовое условие
				{
					Value = value + 1;
				}
				else
				{
					Value = value;
				}
			}
		}
	}


	class Program
	{
		static void Main(string[] args)
		{
			Triangle[] mass = {
			new Triangle(new Point{x=0,y=0},new Point{x=5,y=5},new Point{x=10,y=0}),
			new Triangle(new Point{x=1,y=1},new Point{x=7,y=4},new Point{x=12,y=-4}),
			new Triangle(new Point{x=2,y
			=3},new Point{x=12,y=7},new Point{x=25,y=5}),
			new Triangle(new Point{x=1,y=-1},new Point{x=5,y=10},new Point{x=14,y=-1}),
			new Triangle(new Point{x=0,y=0},new Point{x=0,y=8},new Point{x=6,y=0}),
			new Triangle(new Point{x=0,y=0},new Point{x=4,y=7},new Point{x=8,y=0})
			};

			mass[0].Coord();
			mass[0].Sides();
			Console.WriteLine("Стороны треугольника - " + mass[0].x1 + ", " + mass[0].x2 + ", " + mass[0].x3);
			Console.WriteLine("Метод Perimeter - " + mass[0].Perimeter());
			int v = 10;
			mass[0].Method(ref v);
			mass[0].MethodOut(out v);
			Triangle.DrawInfo(mass[0]);

			//a)	
			int count1 = 0, count2 = 0, count3 = 0, count4 = 0;
			Triangle[] mass1 = new Triangle[10];//равнобедренные
			Triangle[] mass2 = new Triangle[10];//равносторонние
			Triangle[] mass3 = new Triangle[10];//прямоугольные
			Triangle[] mass4 = new Triangle[10];//произвольный
			for (int i = 0;i<mass.Length;i++)
			{
				mass[i].Sides();
				double max1 = 0, xx1 = 0, xx2 = 0;
				if (mass[i].x1 > mass[i].x2 && mass[i].x1 > mass[i].x3)
				{ max1 = mass[i].x1; xx1 = mass[i].x2; xx2 = mass[i].x3; }
				if (mass[i].x2 > mass[i].x1 && mass[i].x2 > mass[i].x3)
				{ max1 = mass[i].x2; xx1 = mass[i].x1; xx2 = mass[i].x3; }
				if (mass[i].x3 > mass[i].x2 && mass[i].x3 > mass[i].x1)
				{ max1 = mass[i].x3; xx1 = mass[i].x1; xx2 = mass[i].x2; }

				if ((Math.Pow(xx1, 2) + Math.Pow(xx2, 2)) == Math.Pow(max1, 2))
				{
					mass3[count3] = mass[i];
					count3++;
					if (mass[i].x1 == mass[i].x2 || mass[i].x1 == mass[i].x3 || mass[i].x2 == mass[i].x3)
					{
						mass1[count1] = mass[i];
						count1++;
					}
				}
				else
				{
					if (mass[i].x1 == mass[i].x2 || mass[i].x1 == mass[i].x3 || mass[i].x2 == mass[i].x3)
					{
						mass1[count1] = mass[i];
						count1++;
						if ((int)mass[i].x1 == (int)mass[i].x2 && (int)mass[i].x1 == (int)mass[i].x3 && (int)mass[i].x2 == (int)mass[i].x3)
						{
							mass2[count2] = mass[i];
							count2++;
						}
					}
					else { mass4[count4] = mass[i];
						count4++;
					}
				}


			}
			Console.WriteLine("Равнобедренных - " + count1);
			Console.WriteLine("Равносторонних - " + count2);
			Console.WriteLine("Прямоугольных - " + count3);
			Console.WriteLine("Произвольных - " + count4);
			//б)
			double k=0, k1 = 10; int max=0, min=0;
			for(int i = 0; i < count1;i++)
			{
				if(mass1[i].Perimeter() < k1)
				{ k1 = mass1[i].Perimeter();min = i; }
				if(mass1[i].Perimeter() > k)
				{ k = mass1[i].Perimeter();max = i; }
			}
			if (count1 != 0)
			{
				Console.WriteLine("Равнобедренный с наибольшим периметром - " + k);
				Console.WriteLine("Равнобедренный с наименьшим периметром - " + k1);
			}
			k = 0; k1 = 10;
			for (int i = 0; i < count2; i++)
			{
				if (mass2[i].Perimeter() < k1)
				{ k1 = mass1[i].Perimeter(); min = i; }
				if (mass2[i].Perimeter() > k)
				{ k = mass2[i].Perimeter(); max = i; }
			}if (count2 != 0)
			{
				Console.WriteLine("Равносторонний с наибольшим периметром - " + k);
				Console.WriteLine("Равносторонний с наименьшим периметром - " + k1);
			}
			k = 0; k1 = 10;
			for (int i = 0; i < count3; i++)
			{
				if (mass3[i].Perimeter() < k1)
				{ k1 = mass3[i].Perimeter(); min = i; }
				if (mass3[i].Perimeter() > k)
				{ k = mass3[i].Perimeter(); max = i; }
			}
			if (count3 != 0)
			{
				Console.WriteLine("Прямоугольный с наибольшим периметром - " + k);
				Console.WriteLine("Прямоугольный с наименьшим периметром - " + k1);
			}
			k = 0; k1 = 10;
			for (int i = 0; i < count4; i++)
			{
				if (mass4[i].Perimeter() < k1)
				{ k1 = mass4[i].Perimeter(); min = i; }
				if (mass4[i].Perimeter() > k)
				{ k = mass4[i].Perimeter(); max = i; }
			}if (count4 != 0)
			{
				Console.WriteLine("Произвольный с наибольшим периметром - " + k);
				Console.WriteLine("Произвольный с наименьшим периметром - " + k1);
			}
		}
	}
	
}

