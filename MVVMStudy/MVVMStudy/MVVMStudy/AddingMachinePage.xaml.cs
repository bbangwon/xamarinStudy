using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMStudy
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddingMachinePage : ContentPage
	{
		public AddingMachinePage (AdderViewModel viewModel)
		{
			InitializeComponent ();
            BindingContext = viewModel;


        }

        private void OnPageSizeChanged(object sender, EventArgs e)
        {
            if(Width < Height)
            {
                mainGrid.RowDefinitions[1].Height = GridLength.Auto;
                mainGrid.ColumnDefinitions[1].Width = new GridLength(0, GridUnitType.Absolute);

                Grid.SetRow(keypadGrid, 1);
                Grid.SetColumn(keypadGrid, 0);
            }
            else
            {
                mainGrid.RowDefinitions[1].Height = new GridLength(0, GridUnitType.Absolute);
                mainGrid.ColumnDefinitions[1].Width = GridLength.Auto;

                Grid.SetRow(keypadGrid, 0);
                Grid.SetColumn(keypadGrid, 1);
            }
        }
    }
}