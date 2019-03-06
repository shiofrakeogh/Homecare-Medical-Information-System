using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Input;

namespace HMIS.ViewModels
{
    public class ExerciseViewModel : INotifyPropertyChanged
    {
        private string _exercisetype;
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ExerciseViewModel()
        {

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
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Exercise(exercise_type)VALUES(@ExerciseType)";
            cmd.Parameters.AddWithValue("@ExerciseType", ExerciseType);

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
        }
    }
}
