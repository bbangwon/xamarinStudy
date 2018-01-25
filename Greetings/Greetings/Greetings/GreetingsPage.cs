using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Greetings
{
	public class GreetingsPage : ContentPage
	{
		public GreetingsPage ()
		{
            Content = new Label
            {
                Text = "인사말, Xamarin Forms",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                FontAttributes = FontAttributes.Bold | FontAttributes.Italic
            };
		}
	}
}