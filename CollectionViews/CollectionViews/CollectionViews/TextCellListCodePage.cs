using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CollectionViews
{
	public class TextCellListCodePage : ContentPage
	{
		public TextCellListCodePage ()
		{
            DataTemplate dataTemplate = new DataTemplate(typeof(TextCell));
            dataTemplate.SetBinding(TextCell.TextProperty, "FriendlyName");
            dataTemplate.SetBinding(TextCell.DetailProperty, new Binding(path: "RgbDisplay", stringFormat: "RGB = {0}"));

            Padding = new Thickness(10, (Device.RuntimePlatform == Device.iOS) ? 20 : 0, 10, 0);
            Content = new ListView
            {
                ItemsSource = Xamarin.Forms.Toolkit.NamedColor.All,
                ItemTemplate = dataTemplate
            };
		}
	}
}