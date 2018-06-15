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
	public partial class SliderDemoPage : ContentPage
	{
		public SliderDemoPage ()
		{
			InitializeComponent ();            
		}

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Slider slider = (Slider)sender;
            if(label != null)
                label.Text = String.Format("Slider = {0:F2}", slider.Value);
        }
    }
}