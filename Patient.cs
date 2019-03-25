using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HMIS.Models
{
    public class Patient : INotifyPropertyChanged
    {
        string name;
        int phoneNum;
        string address;
        string gender;
        int age;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("name");
            }
        }

        public int PhoneNumber
        {
            get { return phoneNum; }
            set
            {
                phoneNum = value;
                OnPropertyChanged("phoneNum");
            }
        }

        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged("gender");
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged("age");
            }
        }
    }
}
