using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Bitmaps
{
	public class ResourceBitmapCodePage : ContentPage
	{
		public ResourceBitmapCodePage ()
		{
            Content = new Image
            {
                Source = ImageSource.FromResource("Bitmaps.Images.ModernUserInterface256.jpg"),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
		}
	}
}