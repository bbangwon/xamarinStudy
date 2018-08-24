using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AsyncAndFileIO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NothingAlertPage : ContentPage
    {
        public NothingAlertPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            label.Text = "Display alert box";
            await DisplayAlert("Simple Alert", "Click 'dismiss' to dismiss", "dismiss");
            label.Text = "Alert has been dismissed";
        }
    }
}