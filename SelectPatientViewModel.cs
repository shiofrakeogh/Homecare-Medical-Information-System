using HMIS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Input;

namespace HMIS.ViewModels
{
    class SelectPatientViewModel : INotifyPropertyChanged
    {
        private string _name;
        private int _phoneNum;
        private string _gender;
        private string _address;
        private int _age;
        User user { get; set; }
        public ObservableCollection<string> Patients { get; set; }
        Patient patient = new Patient();
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SelectPatientViewModel(User user1)
        {
            user = user1;
            this.Patients = new ObservableCollection<string>();
            SelectCommand = new DelegateCommand(Select, () => CanSelect);

        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("name");
            }
        }

        public int PhoneNumber
        {
            get { return _phoneNum; }
            set
            {
                _phoneNum = value;
                OnPropertyChanged("phoneNum");
            }
        }

        public string Gender
        {
            get { return _gender; }
            set
            {
                _gender = value;
                OnPropertyChanged("gender");
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged("age");
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged("address");
            }
        }


        public ICommand SelectCommand { get; private set; }

        public bool CanSelect
        {
            get { return true; }

        }

        string connectionString = "Data Source = hmisserver.database.windows.net; Initial Catalog = hmisDB; Persist Security Info = True; User ID = shiofrakeogh; Password = Applepie112";


        public void Select()
        {
            string user_name = user.Name;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandTimeout = 0;
            cmd.CommandText = "SELECT patient_Name FROM Patient_User WHERE user_Name=@user_name";
            cmd.Parameters.AddWithValue("@user_name", user_name);
            con.Open();
            using (SqlDataReader oReader = cmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    patient.Name = oReader["patient_Name"].ToString();
                    Patients.Add(patient.Name);
                }

                con.Close();
            }
        }
    }
}
