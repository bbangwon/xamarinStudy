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
	public partial class NaiveNamedColorListPage : ContentPage
	{
		public NaiveNamedColorListPage ()
		{
			InitializeComponent ();
            listView.ItemsSource = Xamarin.Forms.Toolkit.NamedColor.All.Select(_=>_.ToString());
		}
	}
}