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
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
            this.BindingContext = new RegisterViewModel();
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var carerLabel = new Label();
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                carerLabel.Text = (string)picker.ItemsSource[selectedIndex];
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Home());
        }
    }
}