using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HMIS.Models
{
    class Register : INotifyPropertyChanged
    {
        string name;
        string phoneNum;
        string role;
        string password;

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

        public string PhoneNumber
        {
            get { return phoneNum; }
            set
            {
                phoneNum = value;
                OnPropertyChanged("phoneNum");
            }
        }

        public string Role
        {
            get { return role; }
            set
            {
                role = value;
                OnPropertyChanged("name");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("password");
            }
        }


        [Version]
        public string Version { get; set; }
    }
}
