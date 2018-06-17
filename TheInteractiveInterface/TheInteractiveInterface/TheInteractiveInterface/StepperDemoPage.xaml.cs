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
	public partial class StepperDemoPage : ContentPage
	{
		public StepperDemoPage ()
		{
			InitializeComponent ();

            stepper_ValueChanged(stepper, null);
		}

        private void stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Stepper stepper = (Stepper)sender;
            button.BorderWidth = stepper.Value;
            label.Text = stepper.Value.ToString("F0");
        }
    }
}