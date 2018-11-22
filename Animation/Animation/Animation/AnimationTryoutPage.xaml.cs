using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Animation
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AnimationTryoutPage : ContentPage
	{
		public AnimationTryoutPage ()
		{
			InitializeComponent ();
		}

        private void OnButtonClicked(object sender, EventArgs e)
        {
            button.RotateTo(360);
        }
    }
}