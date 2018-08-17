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
    public partial class AlertLambdasPage : ContentPage
    {
        public AlertLambdasPage()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            Task<bool> task = DisplayAlert("Simple Alert", "Decide on an option", "yes or ok", "no or cancel");
            task.ContinueWith((Task<bool> taskResult) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    label.Text = String.Format("Alert {0} button was pressed", taskResult.Result ? "OK": "Cancel");
                });
            });
            label.Text = "Alert is currently displayed";
        }
    }
}