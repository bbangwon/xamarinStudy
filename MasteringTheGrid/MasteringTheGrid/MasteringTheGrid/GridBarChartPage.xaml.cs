using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasteringTheGrid
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GridBarChartPage : ContentPage
	{
        const int COUNT = 50;
        Random random = new Random();

		public GridBarChartPage ()
		{
			InitializeComponent ();

            List<View> views = new List<View>();
            TapGestureRecognizer tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += OnBoxViewTapped;

            for (int i = 0; i < COUNT; i++)
            {
                BoxView boxView = new BoxView
                {
                    Color = Color.Accent,
                    HeightRequest = 300 * random.NextDouble(),
                    VerticalOptions = LayoutOptions.End,
                    StyleId = RandomNameGenerator()
                };
                boxView.GestureRecognizers.Add(tapGesture);
                views.Add(boxView);
            }

            grid.Children.AddHorizontal(views);
            Device.StartTimer(TimeSpan.FromMilliseconds(15), OnTimerTick);
		}

        string[] vowels = { "a", "b", "i", "o", "u", "ai", "ei", "ie", "ou", "oo" };
        string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "z" };

        private bool OnTimerTick()
        {
            overlay.Opacity = Math.Max(0, overlay.Opacity - 0.0025);
            return true;
        }

        private string RandomNameGenerator()
        {
            int numPieces = 1 + 2 * random.Next(1, 4);
            StringBuilder name = new StringBuilder();

            for (int i = 0; i < numPieces; i++)
            {
                name.Append(i % 2 == 0 ? consonants[random.Next(consonants.Length)] : vowels[random.Next(vowels.Length)]);
            }
            name[0] = Char.ToUpper(name[0]);
            return name.ToString();    
        }

        private void OnBoxViewTapped(object sender, EventArgs e)
        {
            BoxView boxView = (BoxView)sender;
            label.Text = String.Format("The individual known as {0} " + "has a height of {1} centimeters.", boxView.StyleId, (int)boxView.HeightRequest);
            overlay.Opacity = 1;
        }
    }
}