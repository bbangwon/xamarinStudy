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
    public partial class BounceButtonPage : ContentPage
    {
        public BounceButtonPage()
        {
            InitializeComponent();
        }

        async private void OnButtonClicked(object sender, EventArgs e)
        {
            await button.TranslateTo(0, (Height - button.Height) / 2, 1000, Easing.BounceOut);
            await Task.Delay(2000);
            await button.TranslateTo(0, 0, 1000, Easing.SpringOut);
        }
    }
}