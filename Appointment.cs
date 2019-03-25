using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HMIS.Models
{
    public class Appointment : INotifyPropertyChanged
    {
        DateTime eventDate;
        TimeSpan beginTime;
        TimeSpan endTime;
        DateTime endDateAndTime;
        string eventName;
        string eventOrganiser;


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DateTime EventDate
        {
            get { return eventDate; }
            set
            {
                eventDate = value;
                OnPropertyChanged("eventDate");
            }

        }

        public TimeSpan BeginTime
        {
            get { return beginTime; }
            set
            {
                beginTime = value;
                OnPropertyChanged("beginTime");
            }
        }

        public TimeSpan EndTime
        {
            get { return endTime; }
            set
            {
                endTime = value;
                OnPropertyChanged("endTime");
            }
        }

        public string EventName
        {
            get { return eventName; }
            set
            {
                eventName = value;
                OnPropertyChanged("eventName");
            }
        }

        public string EventOrganiser
        {
            get { return eventOrganiser; }
            set
            {
                eventOrganiser = value;
                OnPropertyChanged("eventOrganiser");
            }
        }

        public DateTime EndDateAndTime
        {
            get { return endDateAndTime; }
            set
            {
                endDateAndTime = value;
                OnPropertyChanged("endDateAndTime");
            }
        }
    }
}
