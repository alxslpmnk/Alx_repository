using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using System.Collections;
using System.Windows;
using System.IO;

namespace OOP_Lab_15
{
	class Program
	{
		static void Main(string[] args)
		{
			//#1
			Laba15.Task1();
			//#2
			Laba15.Task2();
			//#3
			Laba15.Task3();
			//#4
			Laba15.Task4();
			//#5
			Laba15.Task5();
			Console.ReadKey();

		}
	}
	public class Laba15
	{
		public static void Task1()
		{
			foreach (Process process in Process.GetProcesses())
			{
				// выводим id и имя процесса

				Console.WriteLine("ID: {0}  \nName: {1} \nIsAlive?: {2} \nMemorySize: {3}",
					process.Id, process.ProcessName, process.Responding, process.VirtualMemorySize64);
				Console.WriteLine("--------------------------------------------------------------");
			}
		}
		public static void Task2()
		{
			AppDomain domain = AppDomain.CurrentDomain;
			Console.WriteLine("Name: {0}", domain.FriendlyName);
			Console.WriteLine("ID: {0}", domain.Id);
			Console.WriteLine("Base Directory: {0}\n", domain.BaseDirectory);
			Console.WriteLine("Сборки:");

			Assembly[] assemblies = domain.GetAssemblies();
			foreach (Assembly asm in assemblies)
				Console.WriteLine(asm.GetName().Name);
			AppDomain Domen2 = AppDomain.CreateDomain("Secondary domain");
			// событие загрузки сборки
			Domen2.AssemblyLoad += Domain_AssemblyLoad;
			// событие выгрузки домена
			Domen2.DomainUnload += Domen2_DomainUnload;
			Console.WriteLine("Домен: {0}", Domen2.FriendlyName);
			Domen2.Load(new AssemblyName("OOP_Lab_15"));
			Assembly[] assembliess = Domen2.GetAssemblies();
			foreach (Assembly asm in assemblies)
				Console.WriteLine(asm.GetName().Name);
			// выгрузка домена
			AppDomain.Unload(Domen2);
			void Domen2_DomainUnload(object sender, EventArgs e)
			{
				Console.WriteLine("Домен выгружен из процесса");
			}
			void Domain_AssemblyLoad(object sender, AssemblyLoadEventArgs e)
			{
				Console.WriteLine("Сборка загружена");
			}
		}
		public static void Task3()
		{
			Random rnd = new Random();
			int[] mas = new int[12];

			for (int i = 0; i < mas.Length; i++)
			{
				mas[i] = rnd.Next(0, 100);
				Console.WriteLine(mas[i]);
				//File.WriteAllText("C://Gavno.txt", string.Join(" ", mas[i]));
				Console.WriteLine($"Имя: {0} \nПриоритет: {1}, \nЖивой?: {2}", Thread.CurrentThread.Name, Thread.CurrentThread.Priority, Thread.CurrentThread.IsAlive);
				Thread.Sleep(1000);
			}
		}
		public static void Task4()
		{
			MyThread mt = new MyThread();
			mt.Thread1();
			Thread backgroundThread = new Thread(new ThreadStart(mt.Thread2));
			backgroundThread.Start();
		}
		public class MyThread
		{
			Random rndm = new Random();
			int[] ppp = new int[30];
			public void Thread1()
			{
				Console.WriteLine("Current thread #1 priority: " + Thread.CurrentThread.Priority);
				for (int i = 0; i < ppp.Length; i++)
				{
					ppp[i] = rndm.Next(0, 100);
					if (ppp[i] % 2 == 0)
					{
						Console.Write("Fisrt thread: " + ppp[i] + "\n");
						Thread.Sleep(1000);
					}
					if (i == 5)
					{
						Thread g = new Thread(Thread2);
						g.Start();
						Thread.CurrentThread.Priority = ThreadPriority.Lowest;
						Console.WriteLine("Current thread #1 priority: " + Thread.CurrentThread.Priority);
					}
					if (i == 15)
					{
						Thread.CurrentThread.Priority = ThreadPriority.Highest;
						Console.WriteLine("Current thread #1 priority: " + Thread.CurrentThread.Priority);
					}

				}
				Console.WriteLine();
			}
			public void Thread2()
			{
				Console.WriteLine("Current thread #2 priority: " + Thread.CurrentThread.Priority);

				for (int i = 0; i < ppp.Length; i++)
				{
					if (ppp[i] % 2 == 1)
					{
						Console.Write("Second thread: " + ppp[i] + "\n");
						Thread.Sleep(200);
					}
					if (i == 5)
					{
						Thread.CurrentThread.Priority = ThreadPriority.Highest;
						Console.WriteLine("Current thread #2 priority: " + Thread.CurrentThread.Priority);
					}
					if (i == 25)
					{
						Thread.CurrentThread.Priority = ThreadPriority.Lowest;
						Console.WriteLine("Current thread #2 priority: " + Thread.CurrentThread.Priority);
					}
				}
				Console.WriteLine();
			}
		}
		public static void Task5()
		{
			int num = 0;
			// устанавливаем метод обратного вызова
			TimerCallback tm = new TimerCallback(Count);
			// создаем таймер
			Timer timer = new Timer(tm, num, 0, 2000);
			void Count(object obj)
			{
				int x = (int)obj;
				for (int i = 1; i < 9; i++, x++)
				{
					Console.WriteLine("{0}", x * i);
				}
			}
		}
	}
}

