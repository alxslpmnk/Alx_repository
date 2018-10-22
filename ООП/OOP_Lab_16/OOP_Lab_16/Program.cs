using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace OOP_Lab_16
{
	class Program
	{
		static void Main(string[] args)
		{

			// Task 1
			for (int i = 0; i < 2; i++)
			{
				Stopwatch kek = new Stopwatch();
				kek.Start();
				Task lol = new Task(Laba16.Task1);
				Console.WriteLine("\nCurrent task id is: " + lol.Id);
				Console.WriteLine("\nCurrent task status is: " + lol.Status);
				Console.WriteLine("\nDeos task completed?: " + lol.IsCompleted);
				lol.Start();
				lol.Wait();
				Console.WriteLine("\nCurrent task status is: " + lol.Status);
				Console.WriteLine("\nDeos task completed?: " + lol.IsCompleted);
				kek.Stop();
				TimeSpan ts = kek.Elapsed;
				string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}\n", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
				Console.WriteLine("\nRunTime " + elapsedTime);
			}
			// Task 2
			Task lol1 = new Task(Laba16.Task2);
			lol1.Start();
			lol1.Wait();
			//Task 3
			Laba16.Task3_1();
			Laba16.Task3_2();
			Laba16.Task3_3();
			//Task 4
			Console.WriteLine("------------------------------------------------------------------------\nTask 4: ");

			Task task1 = new Task(() => {
				Console.WriteLine("Id задачи: {0}", Task.CurrentId);
			});
			Task task2 = task1.ContinueWith(Display);
			task1.Start();
			task2.Wait();
			Task t = DisplayResultAsync();
			DisplayResultAsync().GetAwaiter().GetResult();
			Console.WriteLine("Задача DisplayResultAsync завершена");
			t.Wait();
			Thread.Sleep(3000);
			// Task 5
			Console.WriteLine("------------------------------------------------------------------------\nTask 5: ");
			Console.WriteLine("PARALLEL FOR");
			Parallel.For(1, 10, Factorial);
			Thread.Sleep(1000);
			Console.WriteLine("PARALLEL FOREACH");
			ParallelLoopResult loop = Parallel.ForEach<int>(new List<int>() { 1, 3, 5, 8 }, Factorial);
			// Task 6
			Console.WriteLine("------------------------------------------------------------------------\nTask 6: ");
			Parallel.Invoke(Display, () => {
				Console.WriteLine("Выполняется задача {0}", Task.CurrentId);
				Thread.Sleep(3000);
			},
			() => Factorial(5));
			// Task 7
			Console.WriteLine("------------------------------------------------------------------------\nTask 7: ");
			BlockCollection Anton = new BlockCollection();
			while (true)
			{
				Task task12 = Task.Factory.StartNew(Anton.Pokupka);
				Task task11 = Task.Run(() => Anton.Zavoz());


				Task.WaitAll(task1, task2);
			}
			// Task 8
			Console.WriteLine("------------------------------------------------------------------------\nTask 8: ");
			DisplayResultAsync();
			Console.ReadLine();
		}
		static void Data(Task t)
		{
			var b = DateTime.Now;
			Console.WriteLine("{0} hours {1} minutes {2} seconds", b.Hour, b.Minute, b.Second);
		}
		static void Display()
		{
			Console.WriteLine("Выполняется задача {0}", Task.CurrentId);
			Thread.Sleep(3000);
		}
		static void Display(Task t)
		{
			Console.WriteLine("Id задачи: {0}", Task.CurrentId);
			Console.WriteLine("Id предыдущей задачи: {0}", t.Id);
		}
		static async Task DisplayResultAsync()
		{
			int num = 5;

			int result = await FactorialAsync(num);
			Console.WriteLine("Факториал числа {0} равен {1}", num, result);
		}
		static void Factorial(int x)
		{
			int result = 1;

			for (int i = 1; i <= x; i++)
			{
				result *= i;
			}
			Console.WriteLine("Выполняется задача {0}", Task.CurrentId);
			Console.WriteLine("Факториал числа {0} равен {1}", x, result);
			Thread.Sleep(3000);
		}
		static Task<int> FactorialAsync(int x)
		{
			int result = 1;

			return Task.Run(() =>
			{
				for (int i = 1; i <= x; i++)
				{
					result *= i;
				}
				return result;
			});
		}
	}
	public static class Laba16
	{
		public static void Task3_1()
		{
			var t = Task<int>.Factory.StartNew(() =>
			{
				// Просто цикл на 10 итераций с условием: возврат итератора происходит немедленно если число итераций достигнет 3 или системное время перевалит за 6 часов.
				Console.WriteLine("------------------------------------------------------------------------\nTask 3_1: ");
				int numberofiteration = 10;
				int iterator;
				for (iterator = 0; iterator <= numberofiteration; iterator++)
				{
					if (iterator == numberofiteration / 3 || DateTime.Now.Hour <= 6)
					{
						iterator++;
						break;
					}
				}
				return iterator;
			});

			Console.WriteLine("Цикл прошёл {0} раз(a)", t.Result);
		}
		public static void Task3_2()
		{
			var t = Task<int>.Factory.StartNew(() =>
			{
				Console.WriteLine("------------------------------------------------------------------------\nTask 3_2: ");
				int numberofiteration = 10;
				int iterator;
				int y = 1;
				for (iterator = 1; iterator <= numberofiteration; iterator++)
				{
					y *= iterator;
				}
				return y;
			});
			Console.WriteLine("Факториал 10 = {0}", t.Result);
		}
		public static void Task3_3()
		{
			var t = Task<double>.Factory.StartNew(() =>
			{
				Console.WriteLine("------------------------------------------------------------------------\nTask 3_3: ");
				Console.WriteLine("Input x");
				int x = int.Parse(Console.ReadLine());
				double y = Math.Cos(x);
				return y;
			});
			Console.WriteLine("Cos x = {0}", t.Result);
		}
		public static void Task1() // решето Эратосфена
		{

			Console.WriteLine("Task 1: ");
			Console.WriteLine("Enter low limit: ");
			int a = int.Parse(Console.ReadLine());
			Console.WriteLine("Enter high limit: ");
			int b = int.Parse(Console.ReadLine());

			bool[] table = new bool[b];
			int i, j;

			for (i = 0; i < table.Length; i++)
				table[i] = true;

			for (i = 2; i * i < table.Length; i++)
				if (table[i])
					for (j = 2 * i; j < table.Length; j += i)
						table[j] = false;

			for (i = 2; i < table.Length; i++)
				if (table[i])
				{
					if (i >= a)
						Console.Write(i + " ");
				}

		}
		public static void Task2()
		{
			CancellationTokenSource source = new CancellationTokenSource();
			CancellationToken token = source.Token;
			if (source.IsCancellationRequested)
			{
				Console.WriteLine("Операция прервана");
				return;
			}
			Console.WriteLine("------------------------------------------------------------------------\nTask 2: ");
			Console.WriteLine("Enter low limit: ");
			int a = int.Parse(Console.ReadLine());
			Console.WriteLine("Enter high limit: ");
			int b = int.Parse(Console.ReadLine());
			if (b < a)
			{
				source.Cancel();
			}
			bool[] table = new bool[b];
			int i, j;

			for (i = 0; i < table.Length; i++)
				table[i] = true;

			for (i = 2; i * i < table.Length; i++)
				if (table[i])
					for (j = 2 * i; j < table.Length; j += i)
						table[j] = false;

			for (i = 2; i < table.Length; i++)
				if (table[i])
				{
					if (i >= a)
						Console.Write(i + " ");
				}
		}
		public static void Task8()
		{
			async Task DisplayResultAsync()
			{
				int num = 5;

				int result = await FactorialAsync(num);
				Console.WriteLine("Факториал числа {0} равен {1}", num, result);
			}
			Task<int> FactorialAsync(int x)
			{
				int result = 1;

				return Task.Run(() =>
				{
					for (int i = 1; i <= x; i++)
					{
						result *= i;
					}
					return result;
				});
			}
		}
	}
	public class BlockCollection
	{
		ArrayList arraylist = new ArrayList();
		public void Zavoz()
		{
			Console.WriteLine("На складе сейчас: " + arraylist.Count);
			Random lol = new Random();
			int a = lol.Next(1, 100);
			arraylist.Add(a);
			Console.WriteLine("Грузчик №{0} На склад завезли {1}", Task.CurrentId, a);
			if (arraylist.Count == 0)
			{
				throw new Exception("Склад пуст!");
			}
			Thread.Sleep(1000);
		}

		public void Pokupka()
		{
			try
			{
				arraylist.RemoveAt(0);
				arraylist.RemoveAt(0);
			}
			catch (Exception ex)
			{
				string a = " ";
				Console.WriteLine("Склад пуст! Клиент ушёл недовольным!!!{0}", a, ex.Source);
			}
			Console.WriteLine("Покупатель №{0} забрал со склада", Task.CurrentId);
			Thread.Sleep(500);
		}

	}
}
