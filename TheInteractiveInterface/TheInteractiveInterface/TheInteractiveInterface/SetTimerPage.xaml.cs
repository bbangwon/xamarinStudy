using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheInteractiveInterface
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SetTimerPage : ContentPage
	{
        DateTime triggerTime;
		public SetTimerPage ()
		{
			InitializeComponent ();

            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);

		}

        bool OnTimerTick()
        {

            if(@switch.IsToggled && DateTime.Now >= triggerTime)
            {
                @switch.IsToggled = false;
                DisplayAlert("Timer Alert", "The '" + entry.Text + "' timer has elapsed", "OK");
            }

            return true;
        }

        private void timePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Time")
            {
                SetTriggerTime();
            }
        }

        private void switch_Toggled(object sender, ToggledEventArgs e)
        {
            SetTriggerTime();
        }

        void SetTriggerTime()
        {
            if(@switch.IsToggled)
            {
                triggerTime = DateTime.Today + timePicker.Time;

                if(triggerTime < DateTime.Now)
                {
                    triggerTime += TimeSpan.FromDays(1);
                }
            }
        }
    }
}