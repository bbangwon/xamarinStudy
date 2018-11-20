using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnalogClock
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MinimalBoxViewClockPage : ContentPage
	{
		public MinimalBoxViewClockPage ()
		{
			InitializeComponent ();
		}

        private void OnAbsoluteLayoutSizeChanged(object sender, EventArgs e)
        {
            AbsoluteLayout absoluteLayout = (AbsoluteLayout)sender;

            Point center = new Point(absoluteLayout.Width / 2, absoluteLayout.Height / 2);
            double radius = Math.Min(absoluteLayout.Width, absoluteLayout.Height) / 2;

            AbsoluteLayout.SetLayoutBounds(hourHand, new Rectangle(center.X - radius * 0.05, center.Y - radius * 0.6, radius * 0.1, radius * 0.6));
            AbsoluteLayout.SetLayoutBounds(minuteHand, new Rectangle(center.X - radius * 0.025, center.Y - radius * 0.7, radius * 0.05, radius * 0.7));
            AbsoluteLayout.SetLayoutBounds(secondHand, new Rectangle(center.X - radius * 0.01, center.Y - radius * 0.9, radius * 0.02, radius * 0.9));

            hourHand.AnchorY = 1;
            minuteHand.AnchorY = 1;
            secondHand.AnchorY = 1;
        }
    }
}