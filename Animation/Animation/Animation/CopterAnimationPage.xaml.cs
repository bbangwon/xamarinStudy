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
	public partial class CopterAnimationPage : ContentPage
	{
		public CopterAnimationPage ()
		{
			InitializeComponent ();

            AnimationLoop();
		}

        async private void AnimationLoop()
        {
            while (true)
            {
                revolveTarget.Rotation = 0;
                copterView.Rotation = 0;

                await Task.WhenAll(revolveTarget.RotateTo(360, 5000),
                    copterView.RotateTo(360 * 5, 5000));
            }
        }
    }
}