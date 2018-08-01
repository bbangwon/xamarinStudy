using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollectionViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewLoggerPage : ContentPage
	{
		public ListViewLoggerPage ()
		{
			InitializeComponent ();

            ObservableCollection<DateTime> list = new ObservableCollection<DateTime>();
            listView.ItemsSource = list;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                list.Add(DateTime.Now);
                return true;
            });

		}
	}
}