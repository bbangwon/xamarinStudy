using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DealingWithSizes
{
	public class FitToSizeClockPage : ContentPage
	{
		public FitToSizeClockPage ()
		{
            Label clockLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            Content = clockLabel;

            SizeChanged += (object sender, EventArgs args) =>
            {
                if (this.Width > 0)
                    clockLabel.FontSize = this.Width / 6;
            };

            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                clockLabel.Text = DateTime.Now.ToString("h:mm:ss tt");
                return true;
            });           


        }
	}
}