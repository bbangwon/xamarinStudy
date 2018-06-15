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
	public partial class RgbSlidersPage : ContentPage
	{
		public RgbSlidersPage ()
		{
			InitializeComponent ();

            redSlider.Value = 128;
            greenSlider.Value = 128;
            blueSlider.Value = 128;
		}

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            if(sender == redSlider)
            {
                redLabel.Text = string.Format("Red = {0:X2}", (int)redSlider.Value);
            }
            else if(sender == greenSlider)
            {
                greenLabel.Text = string.Format("Green = {0:X2}", (int)greenSlider.Value);
            }
            else if(sender == blueSlider)
            {
                blueLabel.Text = string.Format("Blue = {0:X2}", (int)blueSlider.Value);
            }

            boxView.Color = Color.FromRgb((int)redSlider.Value, (int)greenSlider.Value, (int)blueSlider.Value);
        }
    }
}