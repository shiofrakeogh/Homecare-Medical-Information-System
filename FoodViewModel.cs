using HMIS.Models;
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
    public class FoodViewModel : INotifyPropertyChanged
    {
        public User user { get; set; }
        public Patient patient { get; set; }
        private string _fooditem;
        public ObservableCollection<Food> FoodItems { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public FoodViewModel(User user1, Patient patient1, ObservableCollection<Food> FoodItems1)
        {
            user = user1;
            patient = patient1;
            FoodItems = FoodItems1;
            SaveCommand = new DelegateCommand(Save, () => CanSave);
       
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
        public ICommand SaveCommand { get; private set; }

        public bool CanSave
        {
            get { return string.IsNullOrEmpty(FoodItem); }
 
        }

        string connectionString = "Data Source = hmisserver.database.windows.net; Initial Catalog = hmisDB; Persist Security Info = True; User ID = shiofrakeogh; Password = Applepie112";

        
        public void Save()
        {
            string patientName = patient.Name;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Food(Fooditem, patientName)VALUES(@FoodItem, @patientName)";
            cmd.Parameters.AddWithValue("@FoodItem", FoodItem);
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
            Food food = new Food();
            food.FoodItem = FoodItem;
            /*DataRowView rowView = FoodItems.AddNew();
            rowView["Fooditem"] = food.FoodItem;
            rowView.EndEdit();*/
            
            FoodItems.Add(food);
        }
    }
}
