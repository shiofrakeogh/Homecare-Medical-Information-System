using HMIS.Models;
using HMIS.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HMIS.ViewModels
{
    class LogInViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _phoneNum;
        private string _role;
        private string _password;
        public User User { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public LogInViewModel()
        {
            User = new User();
            LogInCommand = new DelegateCommand(LogIn, () => CanLogIn);

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

        public string PhoneNumber
        {
            get { return _phoneNum; }
            set
            {
                _phoneNum = value;
                OnPropertyChanged("phoneNum");
            }
        }

        public string Role
        {
            get { return _role; }
            set
            {
                _role = value;
                OnPropertyChanged("role");
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("password");
            }
        }

        public ICommand LogInCommand { get; private set; }

        public bool CanLogIn
        {
            get { return string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(PhoneNumber) && string.IsNullOrEmpty(Role) && string.IsNullOrEmpty(Password); }

        }

        string connectionString = "Data Source = hmisserver.database.windows.net; Initial Catalog = hmisDB; Persist Security Info = True; User ID = shiofrakeogh; Password = Applepie112";


        public void LogIn()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandTimeout = 0;
            cmd.CommandText = "SELECT * FROM [User] WHERE [Name]=@Name AND [Password]=@Password";
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Password", Password);

            SqlDataAdapter userLogin = new SqlDataAdapter(cmd);
            DataSet result = new DataSet();

            con.Open();
            userLogin.Fill(result, "Login");
            con.Close();

            if (result.Tables["Login"].Rows.Count > 0)
            {
                User.Name = Name;
                User.Role = Role;
                User.Password = Password;
                User.PhoneNumber = PhoneNumber;
                //Application.Current.MainPage.Navigation.PushAsync(new Home());
                Application.Current.MainPage.Navigation.PushAsync(new SelectPatientPage(User));
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Invalid Login", "Please try again", "Ok");
            }
        }
    }
}
