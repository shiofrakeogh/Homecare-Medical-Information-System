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
	public partial class AddAppointment : ContentPage
	{
		public AddAppointment ()
		{
			InitializeComponent ();
            this.BindingContext = new AppointmentViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //schedule.VisibleDatesChangedEvent += Schedule_VisibleDatesChangedEvent;
            Navigation.PushAsync(new Scheduler());
            //Navigation.PopAsync(true);
        }
    }
}