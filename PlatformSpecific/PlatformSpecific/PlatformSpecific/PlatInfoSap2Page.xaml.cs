using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlatInfoSap2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlatInfoSap2Page : ContentPage
	{
		public PlatInfoSap2Page()
		{
			InitializeComponent ();

            PlatformInfo platformInfo = new PlatformInfo();
            modelLabel.Text = platformInfo.GetModel();
            versionLabel.Text = platformInfo.GetVersion();
            
		}
	}
}