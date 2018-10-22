using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;

namespace OOP_Lab_10
{
	public class Sea : IComparable, IComparer
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

	}

	class Program
	{
		
		public static void Method(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			Console.WriteLine("Произошло событие");
		}
		static void Main(string[] args)
		{

			/* Задание 1 */
			ArrayList x = new ArrayList();
			x.Add(5); x.Add(-10); x.Add(27); x.Add(391); x.Add(4234);
			x.Add("Sampletext");
			x.RemoveAt(2);
			int n = x.Count;
			Console.WriteLine("Количество элементов - " + n);
			for(int i = 0; i<n;i++)
			{
				Console.Write(x[i] + " ");
			}

			Console.WriteLine("");

			/*Задание 2*/
			Queue<int> que = new Queue<int>();
			que.Enqueue(1); que.Enqueue(2); que.Enqueue(3);
			que.Enqueue(4); que.Enqueue(5); que.Enqueue(6);
			int[] mass = new int[10];
			foreach(int el in que)
			{
				Console.Write(el + " ");
			}

			for(int i = 0; i<2;i++)
			{
				que.Dequeue();
			}
			Console.WriteLine("");
			que.Enqueue(2);
			SortedDictionary<string, int> dict = new SortedDictionary<string, int>();
			dict.Add("first", que.Dequeue());
			dict.Add("second", que.Dequeue());
			dict.Add("third", que.Dequeue());
			dict.Add("fourth", que.Dequeue());
			foreach(KeyValuePair<string,int> el in dict)
			{
				Console.WriteLine("Ключ - " + el.Key + ", значение - " + el.Value);
			}

			if(dict.ContainsKey("first")==true)
			{
				Console.WriteLine("Нашли, значение - " + dict["first"]);
			}


			/* Задание 3*/
			Queue<Sea> que1 = new Queue<Sea>();
			Sea x1 = new Sea("1");Sea x2 = new Sea("2324324");
			que1.Enqueue(x1);que1.Enqueue(x2);
			foreach(Sea el in que1)
			{
				Console.WriteLine(el.name);
			}
			que1.Dequeue();
			SortedDictionary<string, Sea> dict1 = new SortedDictionary<string, Sea>();
			dict1.Add("first", que1.Dequeue());
			foreach (KeyValuePair<string, Sea> el in dict1)
			{
				Console.WriteLine("Ключ - " + el.Key + ", значение - " + el.Value);
			}
			if (dict.ContainsKey("first") == true)
			{
				Console.WriteLine("Нашли, значение - " + dict1["first"].name);
			}

			/*Задание 4*/
			var observ = new ObservableCollection<Sea>();
			observ.CollectionChanged += Method;
			observ.Add(x1);observ.Add(x2);
			observ.Remove(x1);
		}
	}
}
