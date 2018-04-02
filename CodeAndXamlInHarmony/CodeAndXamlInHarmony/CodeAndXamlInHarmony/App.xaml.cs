using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CodeAndXamlInHarmony
{
	public partial class App : Application
	{
        const string displayLabelText = "displayLabelText";
        public string DisplayLabelText { get; set; }
		public App ()
		{
			InitializeComponent();

            if (Properties.ContainsKey(displayLabelText))
                DisplayLabelText = (string)Properties[displayLabelText];

			MainPage = new CodeAndXamlInHarmony.MonkeyTabPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
            // Handle when your app sleeps
            Properties[displayLabelText] = DisplayLabelText;
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
