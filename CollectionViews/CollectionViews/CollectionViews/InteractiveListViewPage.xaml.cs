using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Toolkit;
using Xamarin.Forms.Xaml;

namespace CollectionViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InteractiveListViewPage : ContentPage
	{
		public InteractiveListViewPage ()
		{
			InitializeComponent ();

            const int count = 100;
            List<ColorViewModel> colorList = new List<ColorViewModel>(count);
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                ColorViewModel colorViewModel = new ColorViewModel();
                colorViewModel.Color = new Color(random.NextDouble(),
                    random.NextDouble(), random.NextDouble());
                colorList.Add(colorViewModel);
            }
            listView.ItemsSource = colorList;
		}
	}
}