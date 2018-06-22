using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace TheInteractiveInterface
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            MainPage = new NavigationPage(new JustNotesPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
            // Handle when your app sleeps
            ((JustNotesPage)(((NavigationPage)MainPage).CurrentPage)).OnSleep();
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
