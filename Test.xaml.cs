using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMIS
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Test : ContentPage
	{
		public Test ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
  
           using (SqlConnection con = new SqlConnection("Data Source = hmisserver.database.windows.net; Initial Catalog = hmisDB; Persist Security Info = True; User ID = shiofrakeogh; Password = Applepie112"))
           {
               con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "CREATE TABLE Test2 (Firstname INT, Secondname TEXT, Age TEXT)", con))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    Console.WriteLine("Table not created.");
                }
            }
        }
    }
}