using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DataBinding
{
	public class OpacityBindingCodePage : ContentPage
	{
		public OpacityBindingCodePage ()
		{
            Label label = new Label
            {
                Text = "Opacity Binding Demo",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };

            Slider slider = new Slider
            {
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            label.BindingContext = slider;
            label.SetBinding(Label.OpacityProperty, "Value");

            Padding = new Thickness(10, 0);
            Content = new StackLayout
            {
                Children = { label, slider }
            };
		}
	}
}