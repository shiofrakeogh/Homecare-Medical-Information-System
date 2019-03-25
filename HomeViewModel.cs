using HMIS.Models;
using HMIS.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HMIS.ViewModels
{
    class HomeViewModel : INotifyPropertyChanged
    {
        public User user { get; set; }
        public Patient patient { get; set; }
        string _fooditem;
        public ObservableCollection<Food> FoodItems { get; set; }
        public ObservableCollection<Exercise> ExerciseItems { get; set; }
        public ObservableCollection<Medicine> Medication { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public HomeViewModel(User user1, Patient patient1)
        {
            user = user1;
            patient = patient1;
            this.FoodItems = new ObservableCollection<Food>();
            this.ExerciseItems = new ObservableCollection<Exercise>();
            this.Medication = new ObservableCollection<Medicine>();
            GetFoodCommand = new DelegateCommand(GetFood, () => CanGetFood);
            GetExerciseCommand = new DelegateCommand(GetExercise, () => CanGetExercise);
            GetMedicationCommand = new DelegateCommand(GetMedication, () => CanGetMedication);
        }

        public string FoodItem
        {
            get { return _fooditem; }
            set
            {
                _fooditem = value;
                OnPropertyChanged("fooditem");
            }
        }

        public ICommand GetFoodCommand { get; private set; }
        public ICommand GetExerciseCommand { get; private set; }
        public ICommand GetMedicationCommand { get; private set; }

        public bool CanGetFood
        {
            get { return true; }

        }

        public bool CanGetExercise
        {
            get { return true; }

        }

        public bool CanGetMedication
        {
            get { return true; }

        }

        string connectionString = "Data Source = hmisserver.database.windows.net; Initial Catalog = hmisDB; Persist Security Info = True; User ID = shiofrakeogh; Password = Applepie112";


        public void GetFood()
        {
            FoodItems.Clear();
            //DateTime thisDay = DateTime.Today;
            string patientName = patient.Name;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandTimeout = 0;
            cmd.CommandText = "SELECT Fooditem FROM Food WHERE patientName=@patientName";
            cmd.Parameters.AddWithValue("@patientName", patientName);
            //cmd.Parameters.AddWithValue("@thisDay", thisDay);
            con.Open();
            using (SqlDataReader oReader = cmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    Food food = new Food();
                    food.FoodItem = oReader["Fooditem"].ToString();
                    FoodItems.Add(food);
                    
                }

                con.Close();
            }
            Application.Current.MainPage.Navigation.PushAsync(new FoodPage(user, patient, FoodItems));
        }

        public void GetExercise()
        {
            ExerciseItems.Clear();
            string patientName = patient.Name;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandTimeout = 0;
            cmd.CommandText = "SELECT exercise_type FROM Exercise WHERE patientName=@patientName";
            cmd.Parameters.AddWithValue("@patientName", patientName);
            con.Open();
            using (SqlDataReader oReader = cmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    Exercise exercise = new Exercise();
                    exercise.ExerciseType = oReader["exercise_type"].ToString();
                    ExerciseItems.Add(exercise);

                }

                con.Close();
            }
            Application.Current.MainPage.Navigation.PushAsync(new ExercisePage(user, patient, ExerciseItems));
        }

        public void GetMedication()
        {
            Medication.Clear();
            string patientName = patient.Name;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandTimeout = 0;
            cmd.CommandText = "SELECT medName, dosage, refill_date FROM Medication WHERE patientName=@patientName";
            cmd.Parameters.AddWithValue("@patientName", patientName);
            con.Open();
            using (SqlDataReader oReader = cmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    Medicine medicine = new Medicine();
                    medicine.MedName = oReader["medName"].ToString();
                    medicine.Dosage = oReader["dosage"].ToString();
                    DateTime datevalue;
                    if (DateTime.TryParse(oReader["refill_date"].ToString(), out datevalue))
                    {
                        medicine.RefillDate = datevalue;
                    }
                    Medication.Add(medicine);

                }

                con.Close();
            }
            Application.Current.MainPage.Navigation.PushAsync(new MedicinePage(user, patient, Medication));
        }

    } 
}
