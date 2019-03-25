using HMIS.Models;
using HMIS.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMIS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MedicinePage : ContentPage
    {
        public User user { get; set; }
        public Patient patient { get; set; }
        public ObservableCollection<Medicine> Medication { get; set; }
        public MedicinePage(User user1, Patient patient1, ObservableCollection<Medicine> Medication1)
        {
            user = user1;
            patient = patient1;
            Medication = Medication1;
            InitializeComponent();
            this.BindingContext = new MedicineViewModel(user, patient, Medication);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            newMedName.Text = string.Empty;
            newDosage.Text = string.Empty;
        }
    }
}