using Syncfusion.XForms.Buttons;
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
    public partial class PersonalCarePage : ContentPage
    {
        SfSegmentedControl segmentedControl;
        public PersonalCarePage()
        {
            InitializeComponent();
        }
            

       /* private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }*/
    }
}