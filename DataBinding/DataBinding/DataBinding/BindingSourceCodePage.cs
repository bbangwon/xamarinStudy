using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DataBinding
{
	public class BindingSourceCodePage : ContentPage
	{
		public BindingSourceCodePage ()
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

            Binding binding = new Binding
            {
                Source = slider,
                Path = "Value"
            };            

            label.SetBinding(Label.OpacityProperty, binding);

            Padding = new Thickness(10, 0);
            Content = new StackLayout
            {
                Children = { label, slider }
            };
		}
	}
}