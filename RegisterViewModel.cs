using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Input;

namespace HMIS.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _phoneNum;
        private string _role;
        private string _password;
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public RegisterViewModel()
        {

            RegisterCommand = new DelegateCommand(Register, () => CanRegister);

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
        public ICommand RegisterCommand { get; private set; }

        public bool CanRegister
        {
            get { return string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(PhoneNumber) && string.IsNullOrEmpty(Role) && string.IsNullOrEmpty(Password); }

        }

        string connectionString = "Data Source = hmisserver.database.windows.net; Initial Catalog = hmisDB; Persist Security Info = True; User ID = shiofrakeogh; Password = Applepie112";


        public void Register()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandTimeout = 0;
            cmd.CommandText = "INSERT INTO [User](name,phone,role,password)VALUES(@Name,@PhoneNumber,@Role,@Password)";
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            cmd.Parameters.AddWithValue("@Role", Role);
            cmd.Parameters.AddWithValue("@Password", Password);

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
