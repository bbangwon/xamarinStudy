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
    public partial class SwingButtonPage : ContentPage
    {
        public SwingButtonPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            button.AnchorX = 0;
            button.AnchorY = 1;

            await button.RotateTo(90, 3000,
                new Easing(t => 1 - Math.Cos(10 * Math.PI * t) * Math.Exp(-5 * t)));

            await button.TranslateTo(0, (Height - button.Height) / 2 - button.Width, 1000, Easing.BounceOut);

            button.AnchorX = 1;
            button.AnchorY = 0;

            button.TranslationX -= button.Width - button.Height;
            button.TranslationY += button.Width + button.Height;

            await button.RotateTo(180, 1000, Easing.BounceOut);

            await Task.WhenAll(
                button.FadeTo(0, 4000),
                button.TranslateTo(0, -Height, 5000, Easing.CubicIn)
                );

            await Task.Delay(3000);
            button.TranslationX = 0;
            button.TranslationY = 0;
            button.Rotation = 0;
            button.Opacity = 1;
        }
    }
}