using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;

namespace FIles
{
	
    class Program
    {
        public static DateTime now = DateTime.Now;
        static void Main(string[] args)
        {
           
            string buf = "";
			TANLog log = new TANLog();
			log.EventIO += TANLog.OnEvent;
            Console.WriteLine("Введите строку для записи");
			log.Write(Console.ReadLine());
            Console.WriteLine("Построчный вывод из файла: " + log.path);
			log.Read(log.path);
            Console.WriteLine("Введите строку для поиска");
            buf = Console.ReadLine();
            Console.WriteLine("Поиск по строке");
			log.Search(buf);
			///////////////////////////////////////////////////////////
			TANDiskInfo info = new TANDiskInfo();
            info.InfoOfDrivers();
			//////////////////////////
			TANFileInfo fileInfo = new TANFileInfo();
            fileInfo.InfoOfFiles(log.path);


			TANFileManager manager = new TANFileManager();

            manager.ListOfFiles();
            manager.Task2();

            manager.Task3(@"C:\", "txt");

            manager.Task4();
            Console.ReadLine();
        }

		class TANLog
        {
            public delegate void del(string m, string path);

            public event del EventIO;




            public string path = @"C:\TANlogfile.txt";

            public void Write(string s)
            {
                string buf = "";
                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(s);
                    sw.Close();
                }

                Type type = typeof(TANLog);

                foreach (MethodInfo m in type.GetMethods())
                {
                    if (m.Name == "Write")
                    {
                        buf = m.Name;
                    }
                }

                EventIO(buf, path);
            }


            public void Read(string path)
            {
                string buf = "";

                Type type = typeof(TANLog);

                foreach (MethodInfo m in type.GetMethods())
                {
                    if (m.Name == "Read")
                    {
                        buf = m.Name;
                    }
                }

                EventIO(buf, path);
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }


                    sr.Close();

                }
            }


            public void Search(string search)
            {

                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line == search)
                        {

                            Console.WriteLine("Найдено совпадение " + line);
                            sr.ReadLine();
                            Console.WriteLine(sr.ReadLine());

                        }
                    }


                    sr.Close();

                }

            }

            public static void OnEvent(string m, string path)
            {
                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                {

                    sw.WriteLine("Пользователь вызвал метод: " + m);
                    sw.WriteLine("Время: " + now);
                }
            }

        }


        class TANDiskInfo
		{
            DriveInfo[] drives = DriveInfo.GetDrives();

            public void InfoOfDrivers()
            {
                foreach (DriveInfo drive in drives)
                {
                    Console.WriteLine("Название: {0}", drive.Name);
                    Console.WriteLine("Тип: {0}", drive.DriveType);
                    if (drive.IsReady)
                    {
                        Console.WriteLine("Объем диска: {0}", drive.TotalSize);
                        Console.WriteLine("Свободное пространство: {0}", drive.TotalFreeSpace);
                        Console.WriteLine("Метка: {0}", drive.VolumeLabel);
                    }
                    Console.WriteLine();
                }
            }

        }


        class TANFileInfo
		{
            public void InfoOfFiles(string path)
            {

                FileInfo fileInf = new FileInfo(path);
                if (fileInf.Exists)
                {
                    Console.WriteLine("Имя файла: {0}", fileInf.Name);
                    Console.WriteLine("Путь : {0}", path);
                    Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
                    Console.WriteLine("Размер: {0}", fileInf.Length);
                }
            }
        }

        class TANFileManager
		{




            public void ListOfFiles()
            {
                string dirName = "C:\\";
                string[] dirs = Directory.GetDirectories(dirName);
                string[] files = Directory.GetFiles(dirName);
                if (Directory.Exists(dirName))
                {
                    Console.WriteLine("Подкаталоги:");

                    foreach (string s in dirs)
                    {
                        Console.WriteLine(s);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Файлы:");

                    foreach (string s in files)
                    {
                        Console.WriteLine(s);
                    }
                }



            }

            public void Task2()
            {
                string dirName = "C:\\";
                string[] dirs = Directory.GetDirectories(dirName);
                string[] files = Directory.GetFiles(dirName);
                DirectoryInfo directory = new DirectoryInfo("C:\\TANInspect");
                directory.Create();

                string path = @"C:\TANInspect\TANdirinfo.txt";

                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine("Подкаталоги:");

                    foreach (string s in dirs)
                    {
                        sw.WriteLine(s);
                    }
                    sw.WriteLine();
                    sw.WriteLine("Файлы:");

                    foreach (string s in files)
                    {
                        sw.WriteLine(s);
                    }

                    Console.WriteLine("Зaписано");

                }

                string newPath = @"C:\TANInspect\NEWPASdirinfo.txt"; ;
                FileInfo fileInf = new FileInfo(path);
                if (fileInf.Exists)
                {
                    fileInf.CopyTo(newPath, true);
                }
                File.Delete(@"C:\TANInspect\TANdirinfo.txt");


            }

            public void Task3(string dirName, string txt)
            {
                DirectoryInfo directory = new DirectoryInfo("C:\\TANFiles");
                directory.Create();

                string[] files = Directory.GetFiles(dirName, "*." + txt);

                foreach (var s in files)
                {

                    FileInfo fileInf = new FileInfo(s);

                    if (fileInf.ToString() == s)
                    {
                        Console.WriteLine(s);

                        fileInf.CopyTo(@"C:\TANFiles\" + fileInf.Name, true);

                    }
                }

                DirectoryInfo dirInfo = new DirectoryInfo(@"C:\TANInspect");
                dirInfo.Delete(true);
                Directory.Move(@"C:\TANFiles", @"C:\TANInspect\");



            }

            public void Task4()
            {
                string startPath = @"C:\TANInspect";
                string zipPath = @"C:\TANInspect\result.zip";
                string extractPath = @"C:\TANInspect\result";
                /*
                ZipFile.CreateFromDirectory(startPath, zipPath);

                ZipFile.ExtractToDirectory(zipPath, extractPath);
                */
            }
        }
    }
}