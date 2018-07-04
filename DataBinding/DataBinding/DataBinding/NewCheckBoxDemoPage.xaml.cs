using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataBinding
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewCheckBoxDemoPage : ContentPage
	{
		public NewCheckBoxDemoPage ()
		{
			InitializeComponent ();
		}

        private void OnItalicCheckBoxChaged(object sender, bool e)
        {
            if(e)
            {
                label.FontAttributes |= FontAttributes.Italic;
            }
            else
            {
                label.FontAttributes &= ~FontAttributes.Italic;
            }
        }

        private void OnBoldCheckBoxChanged(object sender, bool e)
        {
            if(e)
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