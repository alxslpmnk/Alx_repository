using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Configuration;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Xml;
using System.Xml.Linq;

namespace OOP_Lab_14
{
	[Serializable]
	[DataContract]
	[KnownType(typeof(Transport))]
	[KnownType(typeof(Automobil))]
	[KnownType(typeof(Transport[]))]
	class Program
	{
		static void Main(string[] args)
		{
			Transport Calcatinge = new Automobil("Calcatinge", "Moldovanin", 0, 100, 5);
			Transport UAZ = new Automobil("Nissan", "GTR", 228, 2, 240) as Automobil; // ссылка на абстрактный класс
			Printer car = new Printer();
			Transport BelAZ = new Automobil("BELAZ", "POTATO", 1488, 13, 70) as Transport; // ссылка на абстрактный класс
			Poezd Strela = new Poezd("Strela", "bistraya", 1337, 66, 140);
			Vagon Dima = new Vagon("Dima", "СВ", 228, 1337, 1488);

			Transport[] arr = new Transport[5];
			arr[0] = Calcatinge;
			arr[1] = Dima;
			arr[2] = Strela;
			arr[3] = BelAZ;
			arr[4] = UAZ;
			Container q = new Container();
			q.pozhar = new List<Transport>();
			q.Add(Calcatinge);
			q.Add(UAZ);
			q.Add(BelAZ);
			Controller cont = new Controller();
			BinaryFormatter formatter = new BinaryFormatter();
			// получаем поток, куда будем записывать сериализованный объект
			using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
			{
				formatter.Serialize(fs, Calcatinge);

				Console.WriteLine("Бинарная сериализация:\nОбъект успешно сериализован");
			}
			using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
			{
				Transport newTransport = (Transport)formatter.Deserialize(fs);

				Console.WriteLine("Бинарная десериализация:\nОбъект успешно десериализован");
				Console.WriteLine("Имя: {0}\n" +
					"Цена: {1}\n" +
					"Pасход топлива: {2}\n" +
					"Cкорость: {3}\n", newTransport.Name, newTransport.Price, newTransport.Oil, newTransport.Speed);
			}
			Console.WriteLine("==================================");
			SoapFormatter formatter1 = new SoapFormatter();
			// получаем поток, куда будем записывать сериализованный объект
			using (FileStream fs = new FileStream("people.soap", FileMode.OpenOrCreate))
			{
				formatter.Serialize(fs, Strela);

				Console.WriteLine("SOAP сериализация:\nОбъект сериализован");
			}

			// десериализация
			using (FileStream fs = new FileStream("people.soap", FileMode.OpenOrCreate))
			{
				Transport newTransport = (Transport)formatter.Deserialize(fs);

				Console.WriteLine("SOAP десериализация:\nОбъект успешно десериализован");
				Console.WriteLine("Имя: {0}\n" +
					"Цена: {1}\n" +
					"Pасход топлива: {2}\n" +
					"Cкорость: {3}\n", newTransport.Name, newTransport.Price, newTransport.Oil, newTransport.Speed);
			}
			Console.WriteLine("==================================");
			XmlSerializer formatter2 = new XmlSerializer(typeof(Transport));
			using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
			{
				formatter.Serialize(fs, Strela);

				Console.WriteLine("XML сериализация:\nОбъект сериализован");
			}

			using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
			{
				Transport newTransport = (Transport)formatter.Deserialize(fs);

				Console.WriteLine("XML десериализация:\nОбъект успешно десериализован");
				Console.WriteLine("Имя: {0}\n" +
					"Цена: {1}\n" +
					"Pасход топлива: {2}\n" +
					"Cкорость: {3}\n", newTransport.Name, newTransport.Price, newTransport.Oil, newTransport.Speed);
			}
			Console.WriteLine("==================================");
			DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Automobil));

			using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
			{
				jsonFormatter.WriteObject(fs, BelAZ);
				Console.WriteLine("JSON сериализация:\nОбъект сериализован");
			}

			using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
			{
				Automobil newpeople = (Automobil)jsonFormatter.ReadObject(fs);


				Console.WriteLine("JSON десериализация:\nОбъект успешно десериализован");
				Console.WriteLine("Имя: {0}\n" +
					"Цена: {1}\n" +
					"Pасход топлива: {2}\n" +
					"Cкорость: {3}\n", newpeople.Name, newpeople.Price, newpeople.Oil, newpeople.Speed);

			}
			Console.WriteLine("==================================");
			using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
			{
				formatter.Serialize(fs, arr);

				Console.WriteLine("Сериализация массива:\nОбъект успешно сериализован");
			}
			using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
			{
				Transport[] newTransport = (Transport[])formatter.Deserialize(fs);

				Console.WriteLine("Десериализация массива:\nОбъект успешно десериализован");
				foreach (Transport p in newTransport)
				{
					Console.WriteLine("Имя: {0}\n" +
						"Цена: {1}\n" +
						"Pасход топлива: {2}\n" +
						"Cкорость: {3}\n", p.Name, p.Price, p.Oil, p.Speed);
				}
			}
			Console.WriteLine("Залазим в XML-документ:\n");
			XmlDocument xDoc = new XmlDocument();
			xDoc.Load("test.xml");
			XmlElement xRoot = xDoc.DocumentElement;

			// выбор всех дочерних узлов
			XmlNodeList childnodes = xRoot.SelectNodes("*");
			foreach (XmlNode n in childnodes)
				Console.WriteLine(n.OuterXml);

			Console.WriteLine("Link to XML:\n");
			XDocument xdoc = XDocument.Load("info.xml");
			foreach (XElement phoneElement in xdoc.Element("phones").Elements("phone"))
			{
				XAttribute nameAttribute = phoneElement.Attribute("name");
				XElement companyElement = phoneElement.Element("company");
				XElement priceElement = phoneElement.Element("price");

				if (nameAttribute != null && companyElement != null && priceElement != null)
				{
					Console.WriteLine("Смартфон: {0}", nameAttribute.Value);
					Console.WriteLine("Компания: {0}", companyElement.Value);
					Console.WriteLine("Цена: {0}", priceElement.Value);
				}
				Console.WriteLine();
			}
			Console.Read();
		}
	}
	[DataContract]
	[KnownType(typeof(Automobil))]
	[KnownType(typeof(Transport))]
	[KnownType(typeof(Transport[]))]
	public class Person
	{
		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public int Age { get; set; }

		public Person(string name, int year)
		{
			Name = name;
			Age = year;
		}
	}
	public class InvalidDataContractException : Exception
	{

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

	interface ITransport
	{
		void Buy();
		void Sell();
		String ToString();
	}
	[Serializable]
	[DataContract]
	[KnownType(typeof(Automobil))]
	[KnownType(typeof(Transport))]
	[KnownType(typeof(Transport[]))]
	public abstract class Transport
	{
		public abstract void Buy();
		public abstract void Sell();
		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public int Price { get; set; }
		[DataMember]
		public int Oil { get; set; }
		[DataMember]
		public int Speed { get; set; }


		public Transport(string name, int price, int oil, int speed)
		{
			Name = name;
			Price = price;
			if (price < 0)
			{
				throw new Exception("Бесплатно только у мамки в холодильнике!");
			}
			Oil = oil;
			if (oil < 0)
			{
				throw new Exception("Ну не может такова быць!");
			}
			Speed = speed;
			if (speed < 0)
			{
				throw new Exception("Скорость неверная!");
			}
		}
		public virtual void Display()
		{
			Console.WriteLine(Name + " " + Price + " " + Oil + " " + Speed);
		}

	}
	[Serializable]
	[DataContract]
	[KnownType(typeof(Transport[]))]
	[KnownType(typeof(Transport))]
	[KnownType(typeof(Automobil))]
	class Automobil : Transport
	{
		[DataMember]
		public string Marka { get; set; }
		public Automobil(string name, string marka, int price, int oil, int speed) : base(name, price, oil, speed)
		{
			Marka = marka;
		}
		public override string ToString()
		{
			return (Name + " " + Marka + " " + Price + " " + Oil + " " + Speed);
		}
		public override void Buy()
		{
			Console.WriteLine("Вы купили авто " + Name + "!\n");
		}
		public override void Sell()
		{
			Console.WriteLine("Вы продали авто " + Name + "!\n");
		}
	}
	[DataContract]
	class Dvigatel : Transport
	{
		[DataMember]
		public string Model { get; set; }
		public Dvigatel(string name, string model, int price, int oil, int speed) : base(name, price, oil, speed)
		{
			Model = model;
		}
		public override string ToString()
		{
			return (Name + " " + Model + " " + Price + " " + Oil + " " + Speed);
		}
		public override void Buy() // ссылка на интерфейс
		{
			Console.WriteLine("Вы купили двигатель!\n");
		}
		public override void Sell()
		{
			Console.WriteLine("Вы продали двигатель!\n");
		}

	}
	[Serializable]
	[DataContract]
	class Poezd : Transport
	{
		[DataMember]
		public string Vid { get; set; }
		public Poezd(string name, string vid, int price, int oil, int speed) : base(name, price, oil, speed)
		{
			Vid = vid;
		}
		public override string ToString()
		{
			return (Name + " " + Vid + " " + Price + " " + Oil + " " + Speed);
		}
		public override void Buy()
		{
			Console.WriteLine("Вы купили поезд!\n");
		}
		public override void Sell()
		{
			Console.WriteLine("Вы продали поезд!\n");
		}
	}
	[Serializable]
	[DataContract]
	class Vagon : Transport
	{
		[DataMember]
		public string Type { get; set; }

		public Vagon(string name, string type, int price, int oil, int speed) : base(name, price, oil, speed)
		{
			Type = type;
		}
		public override string ToString()
		{
			return (Name + " " + Type + " " + Price + " " + Oil + " " + Speed);
		}
		public override void Buy()
		{
			Console.WriteLine("Вы купили вэйгон!\n");
		}
		public override void Sell()
		{
			Console.WriteLine("Вы продали вэйгон!\n");
		}
	}
	[DataContract]
	sealed class Express : Transport
	{
		[DataMember]
		public int Time { get; set; }
		public Express(string name, int time, int price, int oil, int speed) : base(name, price, oil, speed)
		{
			Time = time;
		}
		public override string ToString()
		{
			return (Name + " " + Time + " " + Price + " " + Oil + " " + Speed);
		}
		public override void Buy()
		{
			Console.WriteLine("Вы купили express!\n");
		}
		public override void Sell()
		{
			Console.WriteLine("Вы продали express!\n");
		}
	}
	public partial class Laba
	{
		public override bool Equals(object obj)
		{
			return true;
		}


		public override int GetHashCode()
		{
			return 123;
		}



		public Laba()
		{
			Console.WriteLine("Просто лаба)00)");
		}
	}
	[Serializable]
	public class Container
	{
		public List<Transport> pozhar;
		protected int priceOfCars { get; set; }

		public List<Transport> Add(Transport p)
		{
			pozhar.Add(p);
			return pozhar;
		}

		public void Info()
		{
			foreach (Transport pp in pozhar)
			{
				Console.WriteLine(pp.ToString());

			}
		}

		public void PriceOfCars()
		{
			foreach (Transport pp in pozhar)
			{
				priceOfCars += pp.Price;
			}
			Console.WriteLine("Total price -- " + priceOfCars + "$");
		}



	}
	enum perechislenie
	{
		Pozhar, Alesh, Buiko,
	}

	struct NARUTOETOKRUTO
	{
		int razengan;
		string hokage;
	}
	public class Controller : Container
	{


		public void Search(List<Transport> pozhar)
		{
			int speed;
			Console.WriteLine("Input the speed");
			speed = Convert.ToInt32(Console.ReadLine());
			int schetchik = 0;
			foreach (Transport pp in pozhar)
			{
				if (pp.Speed == speed)
				{
					Console.WriteLine("Найдено совпадение");
					Printer printer = new Printer();
					printer.IAmPrinting(pp);
					schetchik++;
				}
			}
			if (schetchik == 0)
			{
				Console.WriteLine("Совпадений не найдено!");
			}
			return;
		}

		public List<Transport> OilSorting(List<Transport> pozhar)
		{

			for (int i = 0; i < pozhar.Count; i++)
			{
				for (int j = i + 1; j < pozhar.Count; j++)
				{
					if (pozhar[i].Oil > pozhar[j].Oil)
					{
						var temp = pozhar[i].Oil;
						pozhar[i].Oil = pozhar[j].Oil;
						pozhar[j].Oil = temp;
					}
				}
				Console.WriteLine(pozhar[i].Oil);
			}

			return pozhar;
		}
	}
	public class Printer
	{

		public void IAmPrinting(Transport p)
		{
			Console.WriteLine("Type: " + p.GetType());
			Console.WriteLine(p.ToString());
		}
	}

}