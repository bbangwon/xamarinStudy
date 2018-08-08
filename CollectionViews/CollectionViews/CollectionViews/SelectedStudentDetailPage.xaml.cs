using SchoolOfFineArt;
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
	public partial class SelectedStudentDetailPage : ContentPage
	{
		public SelectedStudentDetailPage ()
		{
			InitializeComponent ();

            BindingContext = new SchoolViewModel();
		}

        private void OnPageSizeChanged(object sender, EventArgs e)
        {
            if(Width < Height)
            {
                mainGrid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                mainGrid.ColumnDefinitions[1].Width = new GridLength(0);

                mainGrid.RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);
                mainGrid.RowDefinitions[1].Height = new GridLength(1, GridUnitType.Star);

                Grid.SetRow(detailLayout, 1);
                Grid.SetColumn(detailLayout, 0);
            }
            else
            {
                mainGrid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                mainGrid.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);

                mainGrid.RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);
                mainGrid.RowDefinitions[1].Height = new GridLength(0);

                Grid.SetRow(detailLayout, 0);
                Grid.SetColumn(detailLayout, 1);
            }
        }
    }
}