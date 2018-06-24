using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheInteractiveInterface
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DaysBetweenDatesPage : ContentPage
	{
		public DaysBetweenDatesPage ()
		{
			InitializeComponent ();

            OnDatePicker_DateSelected(null, null);
		}

        private void OnDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            int days = (toDatePicker.Date - fromDatePicker.Date).Days;
            resultLabel.Text = String.Format("{0} day{1} between dates", days, days == 1 ? "" : "s");
        }
    }
}