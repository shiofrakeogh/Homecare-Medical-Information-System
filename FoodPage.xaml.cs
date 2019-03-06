﻿using HMIS.ViewModels;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HMIS.Views
{
    public partial class FoodPage : ContentPage
    {

        public FoodPage()
        {
            InitializeComponent();
            this.BindingContext = new FoodViewModel();
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            newItemName.Text = string.Empty;
            
        }
        
    }

}