using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheInteractiveInterface
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SwitchDemoPage : ContentPage
	{
		public SwitchDemoPage ()
		{
			InitializeComponent ();
		}

        private void OnItalicSwitchToggled(object sender, ToggledEventArgs e)
        {
            if(e.Value)
            {
                label.FontAttributes |= FontAttributes.Italic;
            }
            else
            {
                label.FontAttributes &= ~FontAttributes.Italic;
            }
        }

        private void OnBoldSwitchToggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                label.FontAttributes |= FontAttributes.Bold;
            }
            else
            {
                label.FontAttributes &= ~FontAttributes.Bold;
            }
        }
    }
}