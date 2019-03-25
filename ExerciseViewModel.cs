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
    public class ExerciseViewModel : INotifyPropertyChanged
    {
        public User user { get; set; }
        public Patient patient { get; set; }
        private string _exercisetype;
        public ObservableCollection<Exercise> ExerciseItems { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ExerciseViewModel(User user1, Patient patient1, ObservableCollection<Exercise> ExerciseItems1)
        {
            user = user1;
            patient = patient1;
            ExerciseItems = ExerciseItems1;
            SaveCommand = new DelegateCommand(Save, () => CanSave);

        }

        public string ExerciseType
        {
            get { return _exercisetype; }
            set
            {
                _exercisetype = value;
                OnPropertyChanged("exercise_type");
            }
        }
        public ICommand SaveCommand { get; private set; }

        public bool CanSave
        {
            get { return string.IsNullOrEmpty(ExerciseType); }

        }

        string connectionString = "Data Source = hmisserver.database.windows.net; Initial Catalog = hmisDB; Persist Security Info = True; User ID = shiofrakeogh; Password = Applepie112";


        public void Save()
        {
            string patientName = patient.Name;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Exercise(exercise_type, patientName)VALUES(@ExerciseType, @patientName)";
            cmd.Parameters.AddWithValue("@ExerciseType", ExerciseType);
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
            Exercise exercise = new Exercise();
            exercise.ExerciseType = ExerciseType;
            ExerciseItems.Add(exercise);
        }
    }
}
