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
	public partial class DiyGradientBitmapPage : ContentPage
	{
		public DiyGradientBitmapPage ()
		{
			InitializeComponent ();

            int rows = 128;
            int cols = 64;

            BmpMaker bmpMaker = new BmpMaker(cols, rows);

            for(int row=0;row<rows;row++)
                for(int col=0;col<cols;col++)
                {
                    bmpMaker.SetPixel(row, col, 2 * row, 0, 2 * (128 - row));
                }

            ImageSource imageSource = bmpMaker.Generate();
            image.Source = imageSource;
		}
	}
}