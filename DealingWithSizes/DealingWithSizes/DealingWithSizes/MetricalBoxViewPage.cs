using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DealingWithSizes
{
	public class MetricalBoxViewPage : ContentPage
	{
		public MetricalBoxViewPage ()
		{
			Content = new BoxView
            {
                Color = Color.Accent,
                WidthRequest = 64,
                HeightRequest = 160,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
		}
	}
}