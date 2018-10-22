using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_9
{

	public delegate void SomeDelegat();
	class Programmist
	{
		public event SomeDelegat Go;
		public void Rename()
		{
			Console.WriteLine("Переименовать");
			if (Go != null)
				Go();
		}
		public void NewProperty()
		{
			Console.WriteLine("Новое свойство");
			if (Go != null)
				Go();
		}
	}
	public class Language
	{
		string name;
		string attribute;
		public void Show()
		{
			Console.WriteLine(name + ", " + attribute);
		}
		public Language(string x)
		{
			name = x;
		}

		public void OnGo()
		{
			Console.WriteLine("Введите новое название для языка: ");
			name = Console.ReadLine(); 
		}


		public void OnNew()
		{
			Console.WriteLine("Введите описание языка: ");
			attribute = Console.ReadLine();
		}
	}

	class Programm
	{
		static void Main()
		{
			Programmist s = new Programmist();
			Language o1 = new Language("C#");
			Language o2 = new Language("C++");
			o1.Show();o2.Show();
			s.Go += new SomeDelegat(o1.OnGo);
			s.Go += new SomeDelegat(o1.OnNew);
			s.Go += new SomeDelegat(o2.OnGo);
			s.Go += new SomeDelegat(o2.OnNew);
			s.Rename();
			o1.Show();
			o2.Show();

			Action<string[]> HandleString = (string[] str) =>
			{
				str[0] += "some .,,.   text";
			};

			HandleString += (string[] str) =>
			{
				string puntcMarks = "?/,!.:-";
				string newStr = "";

				for (int i = 0; i < str[0].Length; i++)
				{
					bool isPuntcMark = false;

					for (int j = 0; j < puntcMarks.Length; j++)
						if (str[0][i] == puntcMarks[j])
						{
							isPuntcMark = true;
							break;
						}

					if (!isPuntcMark)
						newStr += str[0][i];
				}

				str[0] = newStr;
			};

			HandleString += (string[] str) => {
				string newStr = str[0][0].ToString();

				for (int i = 1; i < str[0].Length; i++)
					if (!(str[0][i] == ' ' && str[0][i - 1] == ' '))
						newStr += str[0][i];

				str[0] = newStr;
			};

			HandleString += (string[] str) =>
			{
				str[0] = str[0].ToUpper();
			};

			string[] s1 = new string[1];
			s1[0] = "He---llo    , ? !! ?  / wo:rld ";

			Console.WriteLine("\nSource string: {0}", s1[0]);
			HandleString(s1);
			Console.WriteLine("Handled string: {0}", s1[0]);
		}
	}

}
