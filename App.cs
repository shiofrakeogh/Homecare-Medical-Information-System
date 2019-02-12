using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Data.SqlClient;


[assembly:XamlCompilation(XamlCompilationOptions.Compile)]
namespace HMIS
{
	public class App : Application
	{
        
                //conn.ConnectionString = "Server=hmisserver.database.windows.net;Database=hmisDB;Trusted_Connection=true;User ID=shiofrakeogh;Password=Applepie112;";
                
            
public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new StartPage());
        
            
}

		protected override void OnStart ()
		{
        // Handle when your app starts
        SqlConnection conn = new SqlConnection("Server = tcp:hmisserver.database.windows.net,1433; Initial Catalog = hmisDB; Persist Security Info = False; User ID = shiofrakeogh; Password =Applepie112; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30");
        conn.Open();
       
    }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
            
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

