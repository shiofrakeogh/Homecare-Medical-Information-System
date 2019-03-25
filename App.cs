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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzUzOTRAMzEzNjJlMzQyZTMwbHFjZ0pMaFU0OENwcUp6N3lBVXVRSFM3cFIza3BsYW5ZcEhVTDdldlBqaz0=");
            // The root page of your application
            MainPage = new NavigationPage(new StartPage())
            {
                BarBackgroundColor = Color.FromHex("#87CEFA"),
                BarTextColor = Color.White,
            };

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

