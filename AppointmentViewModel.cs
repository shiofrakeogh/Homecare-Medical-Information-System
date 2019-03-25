using HMIS.Models;
using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HMIS.ViewModels
{
    public class AppointmentViewModel : INotifyPropertyChanged
    {
        DateTime _eventDate;
        TimeSpan _beginTime;
        TimeSpan _endTime;
        DateTime _endDateAndTime;
        string _eventName;
        string _eventOrganiser;
        public ObservableCollection<Appointment> Appointments { get; set; }
        public ICommand AddAppointmentCommand { get; set; }
        public ICommand ScheduleVisibleDatesChanged { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public AppointmentViewModel()
        {
            this.Appointments = new ObservableCollection<Appointment>();
            AddAppointmentCommand = new DelegateCommand(Add, () => CanAdd);
            //ScheduleVisibleDatesChanged = new Command<VisibleDatesChangedEventArgs>(VisibleDatesChanged);
        }

        public DateTime EventDate
        {
            get { return _eventDate; }
            set
            {
                _eventDate = value;
                OnPropertyChanged("eventDate");
            }

        }

        public TimeSpan BeginTime
        {
            get { return _beginTime; }
            set
            {
                _beginTime = value;
                OnPropertyChanged("beginTime");
            }
        }

        public TimeSpan EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value;
                OnPropertyChanged("endTime");
            }
        }

        public string EventName
        {
            get { return _eventName; }
            set
            {
                _eventName = value;
                OnPropertyChanged("eventName");
            }
        }

        public string EventOrganiser
        {
            get { return _eventOrganiser; }
            set
            {
                _eventOrganiser = value;
                OnPropertyChanged("eventOrganiser");
            }
        }

        public DateTime EndDateAndTime
        {
            get { return _endDateAndTime; }
            set
            {
                _endDateAndTime = value;
                OnPropertyChanged("endDateAndTime");
            }
        }

        

        public bool CanAdd
        {
            get { return string.IsNullOrEmpty(EventName) && string.IsNullOrEmpty(EventOrganiser); }

        }

        string connectionString = "Data Source = hmisserver.database.windows.net; Initial Catalog = hmisDB; Persist Security Info = True; User ID = shiofrakeogh; Password = Applepie112";

        /*private void VisibleDatesChanged(VisibleDatesChangedEventArgs args)
        {
            Appointment appointment = new Appointment();
            appointment.EventName = EventName;
            appointment.EventOrganiser = EventOrganiser;
            appointment.EventDate = EventDate + BeginTime;
            appointment.BeginTime = BeginTime;
            appointment.EndDateAndTime = EventDate + EndTime;
            Appointments.Add(appointment);
        }*/

        public void Add()
        {
            Appointment appointment = new Appointment();
            appointment.EventName = EventName;
            appointment.EventOrganiser = EventOrganiser;
            appointment.EventDate = EventDate + BeginTime;
            appointment.BeginTime = BeginTime;
            appointment.EndTime = EndTime;
            appointment.EndDateAndTime = EventDate + EndTime;
            Appointments.Add(appointment);

            /*Appointment appointment1 = new Appointment();
            appointment.EventName = "Doctor";
            appointment.EventOrganiser = "Shiofra";
            appointment.EventDate = new DateTime(2019, 03, 09, 01, 00, 00);
            appointment.BeginTime = BeginTime;
            appointment.EndTime = new TimeSpan(02, 00, 00);
            Appointments.Add(appointment1);*/


            /*SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandTimeout = 0;
            cmd.CommandText = "INSERT INTO On_Call(eventName)VALUES(@EventName)";
            cmd.Parameters.AddWithValue("@EventName", EventName);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                
            }*/
        }
    }


}
