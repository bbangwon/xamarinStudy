using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasteringTheGrid
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GridRgbSlidersPage : ContentPage
	{
		public GridRgbSlidersPage ()
		{
			InitializeComponent ();
		}

        private void OnPageSizeChanged(object sender, EventArgs e)
        {
            //Portrait mode.
            if(Width < Height)
            {
                mainGrid.RowDefinitions[1].Height = GridLength.Auto;
                mainGrid.ColumnDefinitions[1].Width = new GridLength(0, GridUnitType.Absolute);

                Grid.SetRow(controlPanelStack, 1);
                Grid.SetColumn(controlPanelStack, 0);
            }
            else //Landscape mode.
            {
                mainGrid.RowDefinitions[1].Height = new GridLength(0, GridUnitType.Absolute);
                mainGrid.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);

                Grid.SetRow(controlPanelStack, 0);
                Grid.SetColumn(controlPanelStack, 1);
            }
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            boxView.Color = new Color(redSlider.Value, greenSlider.Value, blueSlider.Value);
        }
    }
}