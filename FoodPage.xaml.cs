using HMIS.Models;
using HMIS.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HMIS.Views
{
    public partial class FoodPage : ContentPage
    {
        public User user { get; set; }
        public Patient patient { get; set; }
        public ObservableCollection<Food> FoodItems { get; set; }

        public FoodPage(User user1, Patient patient1, ObservableCollection<Food> Fooditems1)
        {
            user = user1;
            patient = patient1;
            FoodItems = Fooditems1;
            InitializeComponent();
            this.BindingContext = new FoodViewModel(user, patient, FoodItems);
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            newItemName.Text = string.Empty;
            
        }
        
    }

}