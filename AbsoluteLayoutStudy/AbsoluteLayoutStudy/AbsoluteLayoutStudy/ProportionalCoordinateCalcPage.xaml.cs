using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AbsoluteLayoutStudy
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProportionalCoordinateCalcPage : ContentPage
	{
		public ProportionalCoordinateCalcPage ()
		{
			InitializeComponent ();

            Rectangle[] fractionalRects =
            {
                new Rectangle(0.05, 0.1, 0.90, 0.1),    //outer top
                new Rectangle(0.05, 0.8, 0.90, 0.1),    //outer bottom
                new Rectangle(0.05, 0.1, 0.05, 0.8),    //outer left
                new Rectangle(0.90, 0.1, 0.05, 0.8),    //outer right

                new Rectangle(0.15, 0.3, 0.70, 0.1),    //inner top
                new Rectangle(0.15, 0.6, 0.70, 0.1),    //inner bottom
                new Rectangle(0.15, 0.3, 0.05, 0.4),    //inner left
                new Rectangle(0.80, 0.3, 0.05, 0.4),    //inner right
            };

            foreach (Rectangle fractionalRect in fractionalRects)
            {
                Rectangle layoutBounds = new Rectangle
                {
                    X = fractionalRect.X / (1 - fractionalRect.Width),
                    Y = fractionalRect.Y / (1 - fractionalRect.Height),
                    Width = fractionalRect.Width,
                    Height = fractionalRect.Height
                };

                absoluteLayout.Children.Add(
                    new BoxView
                    {
                        Color = Color.Blue
                    }, layoutBounds, AbsoluteLayoutFlags.All);
            }
		}

        private void ContentView_SizeChanged(object sender, EventArgs e)
        {
            ContentView contentView = (ContentView)sender;
            double height = Math.Min(contentView.Width / 2, contentView.Height);
            absoluteLayout.WidthRequest = 2 * height;
            absoluteLayout.HeightRequest = height;
        }
    }
}