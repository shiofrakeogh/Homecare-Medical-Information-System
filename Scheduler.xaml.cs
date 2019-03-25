using HMIS.ViewModels;
using Syncfusion.SfSchedule.XForms;
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
	public partial class Scheduler : ContentPage
	{
		public Scheduler ()
		{
			InitializeComponent ();
            //this.BindingContext = new AppointmentViewModel();
            //AppointmentViewModel appVM = new AppointmentViewModel();
            // schedule.DataSource = appVM.Appointments;
            //schedule.VisibleDatesChangedEvent += Schedule_VisibleDatesChangedEvent;
            AppointmentViewModel appVM = new AppointmentViewModel();
            schedule.DataSource = appVM.Appointments;

        }

        /*private void Schedule_VisibleDatesChangedEvent(object sender, VisibleDatesChangedEventArgs e)
        {
            AppointmentViewModel appVM = new AppointmentViewModel();
            schedule.DataSource = appVM.Appointments;
        }*/

        private void Add_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddAppointment());
        }
    }
}