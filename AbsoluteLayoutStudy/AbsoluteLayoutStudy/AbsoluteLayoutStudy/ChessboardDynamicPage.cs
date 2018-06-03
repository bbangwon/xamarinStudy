using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AbsoluteLayoutStudy
{
	public class ChessboardDynamicPage : ContentPage
	{
        AbsoluteLayout absoluteLayout;

		public ChessboardDynamicPage ()
		{
            absoluteLayout = new AbsoluteLayout
            {
                BackgroundColor = Color.FromRgb(240, 220, 130),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            for(int i=0;i<32;i++)
            {
                BoxView boxView = new BoxView
                {
                    Color = Color.FromRgb(0, 64, 0)
                };
                absoluteLayout.Children.Add(boxView);
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
            double squareSize = Math.Min(contentView.Width, contentView.Height) / 8;
            int index = 0;

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (((row ^ col) & 1) == 0)
                        continue;

                    View view = absoluteLayout.Children[index];
                    Rectangle rect = new Rectangle(col * squareSize, row * squareSize, squareSize, squareSize);                    
                    AbsoluteLayout.SetLayoutBounds(view, rect);
                    index++;
                }
            }
        }
    }
}