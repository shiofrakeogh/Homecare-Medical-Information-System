using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HMIS.Models
{
    public class Medicine : INotifyPropertyChanged
    {
        string medName;
        string dosage;
        DateTime refillDate;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string MedName
        {
            get { return medName; }
            set
            {
                medName = value;
                OnPropertyChanged("medName");
            }

        }

        public string Dosage
        {
            get { return dosage; }
            set
            {
                dosage = value;
                OnPropertyChanged("dosage");
            }
        }

        public DateTime RefillDate
        {
            get { return refillDate; }
            set
            {
                refillDate = value;
                OnPropertyChanged("refillDate");
            }
        }
    }
}
