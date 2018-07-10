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
	public partial class KeypadGridPage : ContentPage
	{
		public KeypadGridPage ()
		{
			InitializeComponent ();
		}

        private void OnBackspaceButtonClicked(object sender, EventArgs e)
        {
            displayLabel.Text = displayLabel.Text.Substring(0, displayLabel.Text.Length - 1);

            backspaceButton.IsEnabled = displayLabel.Text.Length > 0;
        }

        private void OnDigitButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            displayLabel.Text += button.StyleId;

            backspaceButton.IsEnabled = displayLabel.Text.Length > 0;
        }
    }
}