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
    public partial class CircleButtonPage : ContentPage
    {
        Point center;
        double radius;

        public CircleButtonPage()
        {
            InitializeComponent();
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            center = new Point(absoluteLayout.Width / 2, absoluteLayout.Height / 2);
            radius = Math.Min(absoluteLayout.Width, absoluteLayout.Height) / 2;
            AbsoluteLayout.SetLayoutBounds(button, new Rectangle(center.X - button.Width / 2, center.Y - radius, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            button.Rotation = 0;
            button.AnchorY = radius / button.Height;
            await button.RotateTo(360, 1000);
        }
    }
}