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
    public partial class FadingTextAnimationPage : ContentPage
    {
        public FadingTextAnimationPage()
        {
            InitializeComponent();

            AnimationLoop();
        }

        private void OnPageSizeChanged(object sender, EventArgs e)
        {
            if(Width > 0)
            {
                double fontSize = 0.3 * Width;
                label1.FontSize = fontSize;
                label2.FontSize = fontSize;
            }
        }
        
        async void AnimationLoop()
        {
            while(true)
            {
                await Task.WhenAll(label1.FadeTo(0, 1000),
                    label2.FadeTo(1, 1000));

                await Task.WhenAll(label1.FadeTo(1, 1000),
                    label2.FadeTo(0, 1000));
            }
        }

    }
}