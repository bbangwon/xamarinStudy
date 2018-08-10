using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollectionViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RssFeedPage : ContentPage
	{
		public RssFeedPage ()
		{
			InitializeComponent ();
		}

        private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                ((ListView)sender).SelectedItem = null;

                RssItemViewModel rssItem = (RssItemViewModel)e.SelectedItem;
                webView.Source = rssItem.Link;
                rssLayout.IsVisible = false;
                webLayout.IsVisible = true;
            }
        }

        private void OnBackButtonClicked(object sender, EventArgs e)
        {
            webLayout.IsVisible = false;
            rssLayout.IsVisible = true;

        }
    }
}