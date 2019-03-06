using System;
using System.ComponentModel;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace HMIS.Models
{
    public class Food : INotifyPropertyChanged
    {
        string fooditem;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string FoodItem
        {
            get { return fooditem; }
            set {
                fooditem = value;
                OnPropertyChanged("fooditem");
            }
        }

        [Version]
        public string Version { get; set; }
    }
}
