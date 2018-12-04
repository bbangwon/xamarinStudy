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
            button.Rotation = 0;

            await Task.WhenAny<bool>(
                button.RotateTo(360, 2000),
                button.ScaleTo(5, 1000)
                );
            await button.ScaleTo(1, 1000);
        }
    }
}