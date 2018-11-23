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

        async private void OnButtonClicked(object sender, EventArgs e)
        {
            await button.RotateTo(90, 250);
            await button.RotateTo(-90, 500);
            await button.RotateTo(0, 250);
        }
    }
}