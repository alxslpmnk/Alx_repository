using System.ComponentModel;
using System;
using System.Runtime.CompilerServices;
namespace Test
{
    class Student: INotifyPropertyChanged, IDataErrorInfo
    {
        public int id;
        public string first;
        public string last;
        public int age;
        public string gender; 

        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }
        public string FirstName
        {
            get { return first; }
            set
            {
                first = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string Last
        {
            get { return last; }
            set
            {
                last = value;
                OnPropertyChanged("Last");
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }
        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }
        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Age":
                        if ((Age < 16) || (Age > 100))
                        {
                            error = "Возраст должен быть больше 16 и меньше 100";
                        }
                        break;
                    case "FirstName":
                        if (FirstName == "" || FirstName == null)
                        {
                            error = "Поле 'Имя' не должно быть пустым";
                        }
                        break;
                    case "Last":
                        if (Last == "" || Last == null)
                        {
                            error = "Поле 'Фамилия' не должно быть пустым";
                        }
                        break;
                    case "Gender":
                        if (Gender != "женский" && Gender != "мужской")
                        {
                            error = "Пол должен быть 'женский' или 'мужской'";
                        }
                        break;
                }
                return error;
            }
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
