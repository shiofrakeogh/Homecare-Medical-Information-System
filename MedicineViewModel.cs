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
    public class MedicineViewModel : INotifyPropertyChanged
    {
        public User user { get; set; }
        public Patient patient { get; set; }
        string _medName;
        string _dosage;
        DateTime _refillDate;
        public ObservableCollection<Medicine> Medication { get; set; }
        public ICommand AddMedicationCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MedicineViewModel(User user1, Patient patient1, ObservableCollection<Medicine> Medication1)
        {
            user = user1;
            patient = patient1;
            Medication = Medication1;
            AddMedicationCommand = new DelegateCommand(Add, () => CanAdd);
        
        }

        public string MedName
        {
            get { return _medName; }
            set
            {
                _medName = value;
                OnPropertyChanged("medName");
            }

        }

        public string Dosage
        {
            get { return _dosage; }
            set
            {
                _dosage = value;
                OnPropertyChanged("dosage");
            }
        }

        public DateTime RefillDate
        {
            get { return _refillDate; }
            set
            {
                _refillDate = value;
                OnPropertyChanged("refillDate");
            }
        }

        public bool CanAdd
        {
            get { return string.IsNullOrEmpty(MedName); }

        }

        string connectionString = "Data Source = hmisserver.database.windows.net; Initial Catalog = hmisDB; Persist Security Info = True; User ID = shiofrakeogh; Password = Applepie112";

        public void Add()
        {
            string patientName = patient.Name;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandTimeout = 0;
            cmd.CommandText = "INSERT INTO Medication(medName, dosage, refill_date, patientName)VALUES(@MedName, @Dosage, @RefillDate, @patientName)";
            cmd.Parameters.AddWithValue("@MedName", MedName);
            cmd.Parameters.AddWithValue("@Dosage", Dosage);
            cmd.Parameters.AddWithValue("@RefillDate", RefillDate);
            cmd.Parameters.AddWithValue("@patientName", patientName);

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
                
            }

            Medicine meds = new Medicine();
            meds.MedName = MedName;
            meds.Dosage = Dosage;
            meds.RefillDate = RefillDate;
            Medication.Add(meds);
        }
    }
}
