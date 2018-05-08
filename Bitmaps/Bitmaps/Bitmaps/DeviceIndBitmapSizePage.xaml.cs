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
	public partial class DeviceIndBitmapSizePage : ContentPage
	{
		public DeviceIndBitmapSizePage ()
		{
			InitializeComponent ();
		}

        private void Image_SizeChanged(object sender, EventArgs e)
        {
            Image image = (Image)sender;
            label.Text = String.Format("Render size = {0:F0} x {1:F0}", image.Width, image.Height);
        }
    }
}