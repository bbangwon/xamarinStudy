using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AbsoluteLayoutStudy
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChessboardXamlPage : ContentPage
	{
		public ChessboardXamlPage ()
		{
			InitializeComponent ();
		}

        private void ContentView_SizeChanged(object sender, EventArgs e)
        {
            ContentView contentView = (ContentView)sender;
            double boardSIze = Math.Min(contentView.Width, contentView.Height);
            absoluteLayout.WidthRequest = boardSIze;
            absoluteLayout.HeightRequest = boardSIze;
        }
    }
}