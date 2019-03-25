using HMIS.Models;
using HMIS.ViewModels;
using HMIS.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMIS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public User user { get; set; }
        public Patient patient { get; set; }

        public Home(User user1, Patient patient1)
        {
            user = user1;
            patient = patient1;
            this.BindingContext = new HomeViewModel(user, patient);
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new FoodPage(user, patient));
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PersonalCarePage());
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new MedicinePage());
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new ExercisePage());
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            if ((sender as Button).Text == "Clock In"){
                DateTime now = DateTime.Now.ToLocalTime();
                DisplayAlert("Clocked In", "You have clocked in to visit" + " " + patient.Name + "." + "  " + now, "OK");
                (sender as Button).Text = "Clock Out";
            }
            else if ((sender as Button).Text == "Clock Out")
            {
                DateTime now = DateTime.Now.ToLocalTime();
                DisplayAlert("Clocked Out", "You have clocked out of your visit to" + " " + patient.Name + "." + "  " + now, "OK");
                (sender as Button).Text = "Clock In";
            }
        }

        private void Button_Clicked_5(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Scheduler());

        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddAppointment());
        }
    }
}