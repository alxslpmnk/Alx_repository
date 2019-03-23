using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System;

namespace Test
{
    class ViewModel : INotifyPropertyChanged
    {
        private Student selectedStudent;
        public ObservableCollection<Student> Students { get; set; }
        
        private Command removeCommand;
        private Command addCommand;
        private Command saveCommand;
        public Command AddCommand
        {
            get
            {
                    return addCommand ??
                      (addCommand = new Command(obj =>
                      {
                          Student student = new Student();
                          Random r = new Random();
                          student.id= r.Next(100);
                          Students.Insert(0, student);
                          SelectedStudent = student;                         
                      }));
               
                
            }
        }

        public Command SaveCommand
        {
            
            get
            {
                return saveCommand ??
                    (saveCommand = new Command(obj =>
                    {
                        OnPropertyChanged();
                        Student student = new Student();
                        student = selectedStudent;
                        if (student.first == null || student.last == null || student.gender == null || student.age <=16 || student.age >= 100 )
                        {
                            MessageBox.Show("Проверьте корректность введённых данных");

                        }
                        else
                        {
                            XmlDocument xml = new XmlDocument();
                            xml.Load("Students.xml");
                            XmlElement xRoot = xml.DocumentElement;
                            XmlNode xmlNode = xRoot.SelectSingleNode("Student[@Id='" + student.id + "']");
                            if (xmlNode != null)
                            {
                                xmlNode.ChildNodes[0].InnerText = student.first;
                                xmlNode.ChildNodes[1].InnerText = student.last;
                                xmlNode.ChildNodes[2].InnerText = student.age.ToString();
                                int gen;
                                if (student.gender == "мужской") gen = 0;
                                else gen = 1;
                                xmlNode.ChildNodes[3].InnerText = gen.ToString();
                            }
                            else
                            {
                                XmlElement userElem = xml.CreateElement("Student");

                                XmlAttribute idAttr = xml.CreateAttribute("Id");

                                XmlElement firstElem = xml.CreateElement("FirstName");
                                XmlElement lastElem = xml.CreateElement("Last");
                                XmlElement ageElem = xml.CreateElement("Age");
                                XmlElement genElem = xml.CreateElement("Gender");
                                int gen;
                                if (student.gender == "мужской") gen = 0;
                                else gen = 1;
                                XmlText firstText = xml.CreateTextNode(student.first);
                                XmlText lastText = xml.CreateTextNode(student.last);
                                XmlText ageText = xml.CreateTextNode(student.age.ToString());
                                XmlText genText = xml.CreateTextNode(gen.ToString());
                                XmlText idText = xml.CreateTextNode(student.id.ToString());

                                idAttr.AppendChild(idText);
                                firstElem.AppendChild(firstText);
                                lastElem.AppendChild(lastText);
                                ageElem.AppendChild(ageText);
                                genElem.AppendChild(genText);

                                userElem.Attributes.Append(idAttr);
                                userElem.AppendChild(firstElem);
                                userElem.AppendChild(lastElem);
                                userElem.AppendChild(ageElem);
                                userElem.AppendChild(genElem);
                                xRoot.AppendChild(userElem);
                            }
                            xml.Save("Students.xml");
                        }                       
                    }));
            }
        }

        public Command RemoveCommand
        {
            get
            {
                  return removeCommand ??
                  (removeCommand = new Command(obj =>
                  {
                      if (Students.Count > 0)
                      {
                          DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись?", "Сообщение", MessageBoxButtons.YesNo);
                          if (result == DialogResult.Yes)
                          {
                              Student student = obj as Student;
                              if (student != null)
                              {
                                  Students.Remove(student);
                              }
                              XmlDocument xml = new XmlDocument();
                              xml.Load("Students.xml");
                              XmlElement xRoot = xml.DocumentElement;
                              XmlNode xmlNode = xRoot.SelectSingleNode("Student[@Id='"+student.id.ToString()+"']");
                              xRoot.RemoveChild(xmlNode);
                              xml.Save("Students.xml");
                          }
                      }
                  },
                 (obj) => Students.Count > 0));                
            }
        }
        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                OnPropertyChanged("SelectedStudent");
            }
        }

        public ViewModel()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("Students.xml");
            XmlElement xRoot = xml.DocumentElement;
            Students = new ObservableCollection<Student>();
            foreach (XmlNode xnode in xRoot)
            {
                Student student = new Student();
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("Id");
                    if (attr != null)
                        student.id = int.Parse(attr.InnerText);
                }
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "FirstName")
                    {
                        student.first = childnode.InnerText;
                    }
                    if (childnode.Name == "Last")
                    {
                        student.last = childnode.InnerText;
                    }
                    if (childnode.Name == "Age")
                    {
                        student.age = int.Parse(childnode.InnerText);
                    }
                    if (childnode.Name == "Gender")
                    {
                        if(childnode.InnerText == "1")
                        student.gender = "женский";
                        else student.gender = "мужской";
                    }
                }
                Students.Add(student);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
