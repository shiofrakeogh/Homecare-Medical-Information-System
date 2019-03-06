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
    public partial class ExercisePage : ContentPage
    {
        public ExercisePage()
        {
            InitializeComponent();
            this.BindingContext = new ExerciseViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            newItemName.Text = string.Empty;
        }
    }
}