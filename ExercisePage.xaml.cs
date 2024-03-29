﻿using HMIS.Models;
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
    public partial class ExercisePage : ContentPage
    {
        public User user { get; set; }
        public Patient patient { get; set; }
        public ObservableCollection<Exercise> ExerciseItems { get; set; }

        public ExercisePage(User user1, Patient patient1, ObservableCollection<Exercise> Exerciseitems1)
        {
            user = user1;
            patient = patient1;
            ExerciseItems = Exerciseitems1;
            InitializeComponent();
            this.BindingContext = new ExerciseViewModel(user, patient, ExerciseItems);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            newItemName.Text = string.Empty;
        }
    }
}