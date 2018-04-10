using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DisplayPlatformInfo;

namespace PlatformSpecificPCL
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DisplayPlatformInfoPage : ContentPage
	{
		public DisplayPlatformInfoPage ()
		{
			InitializeComponent ();

            IPlatformInfo platformInfo = DependencyService.Get<IPlatformInfo>();
            modelLabel.Text = platformInfo.GetModel();
            versionLabel.Text = platformInfo.GetVersion();
		}
	}
}