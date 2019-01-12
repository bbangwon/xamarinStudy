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
    public partial class SpinningImagePage : ContentPage
    {        
        public SpinningImagePage()
        {
            InitializeComponent();

            AnimationLoop();
        }

        async private void AnimationLoop()
        {
            uint duration = 5 * 60 * 1000;

            while (true)
            {
                await Task.WhenAll(
                    image.RotateTo(307 * 360, duration),
                    image.RotateXTo(251 * 360, duration),
                    image.RotateYTo(199 * 360, duration)
                    );

                image.Rotation = 0;
                image.RotationX = 0;
                image.RotationY = 0;
            }
            throw new NotImplementedException();
        }
    }
}