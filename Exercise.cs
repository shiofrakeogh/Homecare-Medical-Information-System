using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HMIS.Models
{
    class Exercise : INotifyPropertyChanged
    {
        string id;
        string exercise_type;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("id");
            }

        }

        public string ExerciseType
        {
            get { return exercise_type; }
            set
            {
                exercise_type = value;
                OnPropertyChanged("exercise_type");
            }
        }
    }
}
