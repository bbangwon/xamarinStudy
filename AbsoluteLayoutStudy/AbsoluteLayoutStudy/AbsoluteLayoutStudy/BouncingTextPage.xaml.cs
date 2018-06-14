using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AbsoluteLayoutStudy
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BouncingTextPage : ContentPage
	{
        const double period = 2000;
        readonly DateTime startTime = DateTime.Now;
		public BouncingTextPage ()
		{
			InitializeComponent ();
            Device.StartTimer(TimeSpan.FromMilliseconds(15), OnTimerTick);
		}

        bool OnTimerTick()
        {
            TimeSpan elased = DateTime.Now - startTime;
            double t = (elased.TotalMilliseconds % period) / period;
            t = 2 * (t < 0.5 ? t : 1 - t);

            AbsoluteLayout.SetLayoutBounds(label1,
                new Rectangle(t, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            AbsoluteLayout.SetLayoutBounds(label2,
                new Rectangle(0.5, 1 - t, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));


            return true;
        }
	}
}