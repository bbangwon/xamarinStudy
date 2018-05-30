using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bitmaps
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImageTapPage : ContentPage
	{
		public ImageTapPage ()
		{
			InitializeComponent ();
		}

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Image image = (Image)sender;
            image.Opacity = 0.75;

            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            {
                image.Opacity = 1;
                return false;
            });

            label.Text = String.Format("Rendered Image is {0} x {1}", image.Width, image.Height);
        }


    }
}