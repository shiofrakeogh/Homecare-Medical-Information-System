﻿using HMIS.ViewModels;
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
	public partial class LogInPage : ContentPage
	{
		public LogInPage ()
		{
			InitializeComponent ();
            this.BindingContext = new LogInViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            newName.Text = string.Empty;
            newPassword.Text = string.Empty;
        }
    }
}