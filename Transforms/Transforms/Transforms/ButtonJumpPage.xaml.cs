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
    public partial class ButtonJumpPage : ContentPage
    {
        Random random = new Random();
        public ButtonJumpPage()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            View container = (View)button.Parent;

            button.TranslationX = (random.NextDouble() - 0.5) * (container.Width - button.Width);
            button.TranslationY = (random.NextDouble() - 0.5) * (container.Height - button.Height);
        }
    }
}