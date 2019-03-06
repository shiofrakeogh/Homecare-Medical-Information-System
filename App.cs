using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Data.SqlClient;


[assembly:XamlCompilation(XamlCompilationOptions.Compile)]
namespace HMIS
{
	public class App : Application
	{
        
                
            
public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new StartPage());
            //SqlConnection connection = new SqlConnection("Data Source = hmisserver.database.windows.net; Initial Catalog = hmisDB; Persist Security Info = True; User ID = shiofrakeogh; Password = ***********");

        }

		protected override void OnStart ()
		{
        // Handle when your app starts
        
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

