using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheInteractiveInterface
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TextFadePage : ContentPage
	{
		public TextFadePage ()
		{
			InitializeComponent ();
		}

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            AbsoluteLayout.SetLayoutBounds(label1,
                new Rectangle(e.NewValue, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            AbsoluteLayout.SetLayoutBounds(label2,
                new Rectangle(e.NewValue, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            label1.Opacity = 1 - e.NewValue;
            label2.Opacity = e.NewValue;
        }
    }
}