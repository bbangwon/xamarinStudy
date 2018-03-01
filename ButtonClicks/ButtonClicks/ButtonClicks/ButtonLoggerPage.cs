using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ButtonClicks
{
	public class ButtonLoggerPage : ContentPage
	{
        StackLayout loggerLayout = new StackLayout();
		public ButtonLoggerPage ()
		{
            Button button = new Button
            {
                Text = "Log the Click Time"
            };
            button.Clicked += OnButtonClicked;

            this.Padding = new Thickness(5, 0, 5, 0);

            this.Content = new StackLayout
            {
                Children =
                {
                    button,
                    new ScrollView
                    {
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        Content = loggerLayout
                    }
                }
            };

		}

        private void OnButtonClicked(object sender, EventArgs e)
        {
            loggerLayout.Children.Add(new Label
            {
                Text = "Button clicked at " + DateTime.Now.ToString("T")
            });
        }
    }
}