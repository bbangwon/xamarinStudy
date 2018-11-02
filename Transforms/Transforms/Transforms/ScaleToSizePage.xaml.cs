using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Transforms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScaleToSizePage : ContentPage
    {
        public ScaleToSizePage()
        {
            InitializeComponent();
            UpdateLoop();
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            label.Scale = Math.Min(Width / label.Width, Height / label.Height);
        }

        async void UpdateLoop()
        {
            while(true)
            {
                label.Text = DateTime.Now.ToString("T");
                await Task.Delay(1000);
            }
        }
    }
}