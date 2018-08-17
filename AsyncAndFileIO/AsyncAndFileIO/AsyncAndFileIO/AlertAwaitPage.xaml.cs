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
	public partial class AlertAwaitPage : ContentPage
	{
		public AlertAwaitPage ()
		{
			InitializeComponent ();
		}

        async void OnButtonClicked(object sender, EventArgs e)
        {
            label.Text = "Alert is currently displayed";
            label.Text = String.Format("Alert {0} button was pressed", await DisplayAlert("Simple Alert", "Decide on an option", "yes or ok", "no or cancel") ? "OK" : "Cancel");
        }
    }
}