using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
namespace HMIS.ViewModels
{
    public class FoodViewModel : INotifyPropertyChanged
    {
        private string _fooditem;
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public FoodViewModel()
        {

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
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Food(Fooditem)VALUES(@FoodItem)";
            cmd.Parameters.AddWithValue("@FoodItem", FoodItem);
            
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
                //add a method to read into a listview
            }
        }
    }
}
