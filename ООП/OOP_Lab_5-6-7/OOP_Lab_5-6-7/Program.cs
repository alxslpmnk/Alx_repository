using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization.Json;
using System.Xml.Linq;

namespace OOP_Lab_5_6_7
{
	[Serializable]
	class Program
	{
		static int Abs(int value)
		{
			return (value > 0 ? value : -value);

		}
		static void Main(string[] args)
		{

			Sea p1 = new Sea("Red", 4000);
			Sea p2 = new Sea("Black", 5000);
			Sea p3 = new Sea("Minskoe", 5000);
			Sea p4 = new Sea("Sea", 5000);
			Sea p5 = new Sea("Sea2", 1200);
			/*Task 1*/
			BinaryFormatter formatter1 = new BinaryFormatter();
			using (FileStream fs1 = new FileStream("seas1.dat", FileMode.OpenOrCreate))
			{
				formatter1.Serialize(fs1, p1);
			}
			using (FileStream fs1 = new FileStream("seas1.dat",FileMode.OpenOrCreate))
			{
				Sea newSea = (Sea)formatter1.Deserialize(fs1);
				Console.WriteLine($"Name: {newSea.Name} , Depth: {newSea.Glubina}");
			}
			SoapFormatter formatter2 = new SoapFormatter();
			using (FileStream fs2 = new FileStream("seas2.dat", FileMode.OpenOrCreate))
			{
				formatter2.Serialize(fs2, p1);
			}
			using (FileStream fs2 = new FileStream("seas2.dat", FileMode.OpenOrCreate))
			{
				Sea newSea = (Sea)formatter2.Deserialize(fs2);
				Console.WriteLine($"Name: {newSea.Name} , Depth: {newSea.Glubina}");		
			}
			Point l = new Point();
			l.x = 5;
			XmlSerializer formatter3 = new XmlSerializer(typeof(Point));
			using (FileStream fs3 = new FileStream("point.xml", FileMode.OpenOrCreate))
			{
				formatter3.Serialize(fs3, l);
			}
			using (FileStream fs3 = new FileStream("point.xml", FileMode.OpenOrCreate))
			{
				Point newSea = formatter3.Deserialize(fs3) as Point;
				Console.WriteLine($"X: {newSea.x}");
			}
			DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Point));
			using (FileStream fs = new FileStream("seas.json",FileMode.OpenOrCreate))
			{
				jsonFormatter.WriteObject(fs, l);
			}
			using (FileStream fs = new FileStream("seas.json",FileMode.OpenOrCreate))
			{
				Point newSea =
			  (Point)jsonFormatter.ReadObject(fs);
				Console.WriteLine($"X: {newSea.x}");
			}
			File.Delete("seas.json");
			/*Task 2*/
			Sea[] array = new Sea[5] { p1, p2, p3, p4, p5 };
			BinaryFormatter form = new BinaryFormatter();
			using (FileStream fs = new FileStream("seas234.dat", FileMode.OpenOrCreate))
			{
				form.Serialize(fs, array);
			}
			using (FileStream fs = new FileStream("seas234.dat", FileMode.OpenOrCreate))
			{
				Sea[] Seas =
			  (Sea[])form.Deserialize(fs);
				foreach(Sea newSea in Seas)
				Console.WriteLine($"Name: {newSea.Name} , Depth: {newSea.Glubina}");
			}
			/*Task 3*/
			Console.WriteLine("Открываем XML-документ:\n");
			XmlDocument xDoc = new XmlDocument();
			xDoc.Load("point.xml");
			XmlElement xRoot = xDoc.DocumentElement;

			// выбор всех дочерних узлов
			XmlNodeList childnodes = xRoot.SelectNodes("*");
			foreach (XmlNode n in childnodes)
				Console.WriteLine(n.OuterXml);

			Console.WriteLine("Link to XML:\n");
			XDocument xdoc = XDocument.Load("list.xml");
			foreach (XElement Element in xdoc.Element("LIST").Elements("STUDENT"))
			{
				XElement surnameAttribute = Element.Element("SURNAME");
				XElement nameElement = Element.Element("NAME");
				XElement groupElement = Element.Element("GROUP");
				
				if (surnameAttribute != null && nameElement != null && groupElement != null)
				{
					Console.WriteLine("Фамилия: {0}", surnameAttribute.Value);
					Console.WriteLine("Имя: {0}", nameElement.Value);
					Console.WriteLine("Группа: {0}", groupElement.Value);
				}
				Console.WriteLine();
			}

		}

	}
	class PersonException : Exception
	{
		public override string Message
		{
			get
			{
				return "Error";
			}
		}
	}
	[XmlRoot]
	public class Point
	{
		[XmlAttribute]
		public int x;
	}
	public struct Structura
	{
		enum Days { Mon, Tue, Wed, Thu, Fri, Sat, Sun };
	}
	[Serializable]
	abstract public class Water
	{
		public int percent;
		abstract public void Do();
	}
	[Serializable]
	public class Land : Water
	{
		public int percent;
		virtual public void Print()
		{
			Console.WriteLine(percent);
		}
		override public void Do()
		{
			Console.WriteLine("222");
		}
	}
	[Serializable][DataContract]
	public class Sea : Water, IName
	{
		public Sea()
		{

		}
		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public int Glubina { get; set; }
		public Sea(string name, int glubina)
		{
			Name = name;
			Glubina = glubina;
			if(glubina <=500)
			{ throw new Exception("Слишком маленькая глубина для моря"); }
			}
		override public void Do()
		{
			Console.WriteLine("Реализация метода абстрактного класса");
			Console.WriteLine(Name);
		}
		  void IName.Do()
		 {
			Console.WriteLine("Реализация метода интерфейса");
		 }
		void IName.V()
		{
			Console.WriteLine("111");
		}
	}

	class Continent : Land
	{
		public string name;
		override public void Print()
		{
			Console.WriteLine(name);
		}
	}

	class Island : Land
	{
		public string name;
		public int square;
		public void M()
		{ }
	}

	sealed class State : Continent, IName
	{
		
		public string statename;
		public int population;
		void IName.Do()
		{
			Console.WriteLine(statename);
		}
		void IName.V()
		{
			Console.WriteLine("Sampletext");
		}
	}

	interface IName
	{
		 void Do();
		 void V();
	}

	interface IName2 : IName
	{
		void Do1();
	}

	public class Container
	{
		public List<Water> Earth;
		public List<Water> Add(Water p)
		{
			Earth.Add(p);
			return Earth;
		}
		public void Info()
		{
			foreach (Water pp in Earth)
			{
				Console.WriteLine(pp.ToString());

			}
		}

	}

	public class Controller : Container
	{
		public void Isl(List<Water> Earth)
		{
			foreach(Water pp in Earth)
			{if(pp.GetType()==typeof(Island))
				Console.WriteLine(pp); }
		}

		public void Seas(List<Water> Earth)
		{
			int count = 0;
			foreach (Water pp in Earth)
			{ if (pp.GetType() == typeof(Sea))
					count++;
			}
			Console.WriteLine("Морей: " + count);
		}
		public void IslSorted(List<Water> Earth)
		{ string[] mass = new string[10];
			int i=0;
			foreach (Water pp in Earth)
			{
				if (pp is Island == true)
				{
					Island pp1 = pp as Island;
					mass[i] = pp1.name;
					i++;
				}
			}
			Array.Sort(mass);
			for(int j = 0; j<=i;j++)
			{ Console.WriteLine(mass[j]); }
		}
	}

	
}
