using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace MVVMStudy
{
	public partial class App : Application
	{
        AdderViewModel adderViewModel;
		public App ()
		{
			InitializeComponent();

            adderViewModel = new AdderViewModel();
            adderViewModel.RestoreState(Current.Properties);
            MainPage = new AddingMachinePage(adderViewModel);            
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
            // Handle when your app sleeps
            adderViewModel.SaveState(Current.Properties);
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
