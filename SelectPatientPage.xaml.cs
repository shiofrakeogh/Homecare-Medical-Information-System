using HMIS.Models;
using HMIS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMIS.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectPatientPage : ContentPage
	{
        public User user { get; set; }
        Patient patient = new Patient();

		public SelectPatientPage (User user1)
		{
            user = user1;
            this.BindingContext = new SelectPatientViewModel(user);
			InitializeComponent ();
		}

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                patient.Name = (string)picker.ItemsSource[selectedIndex];
            }

            Navigation.PushAsync(new Home(user, patient));
        }
    }
}