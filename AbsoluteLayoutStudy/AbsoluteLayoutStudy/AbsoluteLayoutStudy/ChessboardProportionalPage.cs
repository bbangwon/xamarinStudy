using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AbsoluteLayoutStudy
{
	public class ChessboardProportionalPage : ContentPage
	{
        AbsoluteLayout absoluteLayout;
		public ChessboardProportionalPage ()
		{
            absoluteLayout = new AbsoluteLayout
            {
                BackgroundColor = Color.FromRgb(240, 220, 130),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center               
            };

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (((row ^ col) & 1) == 0)
                        continue;

                    BoxView boxView = new BoxView
                    {
                        Color = Color.FromRgb(0, 64, 0)
                    };

                    Rectangle rect = new Rectangle(col / 7.0, row / 7.0, 1 / 8.0, 1 / 8.0);
                    absoluteLayout.Children.Add(boxView, rect, AbsoluteLayoutFlags.All);
                }
            }

            ContentView contentView = new ContentView
            {
                Content = absoluteLayout
            };
            contentView.SizeChanged += ContentView_SizeChanged;

            this.Padding = new Thickness(5, (Device.RuntimePlatform == Device.iOS) ? 25 : 5, 5, 5);
            this.Content = contentView;
        }

        private void ContentView_SizeChanged(object sender, EventArgs e)
        {
            ContentView contentView = (ContentView)sender;
            double boardSize = Math.Min(contentView.Width, contentView.Height);
            absoluteLayout.WidthRequest = boardSize;
            absoluteLayout.HeightRequest = boardSize;
        }
    }
}