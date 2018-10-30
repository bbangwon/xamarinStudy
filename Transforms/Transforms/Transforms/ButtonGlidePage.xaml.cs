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
    public partial class ButtonGlidePage : ContentPage
    {
        static readonly TimeSpan duration = TimeSpan.FromSeconds(1);
        Random random = new Random();
        Point startPoint;
        Point animationVector;
        DateTime startTime;

        public ButtonGlidePage()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromMilliseconds(16), OnTimerTick);
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            View Container = (View)button.Parent;

            startPoint = new Point(button.TranslationX, button.TranslationY);

            double endX = (random.NextDouble() - 0.5) * (Container.Width - button.Width);
            double endY = (random.NextDouble() - 0.5) * (Container.Height - button.Height);

            animationVector = new Point(endX - startPoint.X, endY - startPoint.Y);

            startTime = DateTime.Now;
        }

        private bool OnTimerTick()
        {
            TimeSpan elapsedTime = DateTime.Now - startTime;

            double t = Math.Max(0, Math.Min(1, elapsedTime.TotalMilliseconds / duration.TotalMilliseconds));

            button.TranslationX = startPoint.X + t * animationVector.X;
            button.TranslationY = startPoint.Y + t * animationVector.Y;
            return true;
        }


    }
}