using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataBinding
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WebViewDemoPage : ContentPage
	{
		public WebViewDemoPage ()
		{
			InitializeComponent ();
		}

        private void OnEntryCompleted(object sender, EventArgs e)
        {
            webView.Source = ((Entry)sender).Text;
        }

        private void OnCanGoBackClicked(object sender, EventArgs e)
        {
            webView.GoBack();
        }

        private void OnGoForwardClicked(object sender, EventArgs e)
        {
            webView.GoForward();
        }
    }
}