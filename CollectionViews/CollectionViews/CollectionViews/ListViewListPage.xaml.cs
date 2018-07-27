using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollectionViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewListPage : ContentPage
	{
		public ListViewListPage ()
		{
			InitializeComponent ();

            var lColors = new List<Color>
            {
                Color.Aqua, Color.Black, Color.Blue, Color.Fuchsia,
                Color.Gray, Color.Green, Color.Lime, Color.Maroon,
                Color.Navy, Color.Olive, Color.Pink, Color.Purple,
                Color.Red, Color.Silver, Color.Teal, Color.White, Color.Yellow
            };

            listView.ItemsSource = lColors.Select(_ => _.ToString());
        }
	}
}