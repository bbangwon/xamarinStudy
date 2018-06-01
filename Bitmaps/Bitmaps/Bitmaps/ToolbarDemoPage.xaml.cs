using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bitmaps
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ToolbarDemoPage : ContentPage
	{
		public ToolbarDemoPage ()
		{
			InitializeComponent ();
		}

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            ToolbarItem toolbarItem = (ToolbarItem)sender;
            label.Text = "ToolbarItem '" + toolbarItem.Text + "' clicked";
        }
    }
}