using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Transforms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BlockTextPage : ContentPage
	{
		public BlockTextPage ()
		{
			InitializeComponent ();

            for (int i = 0; i < (Device.RuntimePlatform == Device.UWP?18:12); i++)
            {
                grid.Children.Insert(0, new Label { TranslationX = i, TranslationY = -i});
            }
		}
	}
}