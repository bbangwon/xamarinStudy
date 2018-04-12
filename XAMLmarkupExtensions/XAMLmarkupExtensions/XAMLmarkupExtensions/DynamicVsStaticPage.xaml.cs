using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XAMLmarkupExtensions
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DynamicVsStaticPage : ContentPage
	{
		public DynamicVsStaticPage ()
		{
			InitializeComponent ();

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Resources["currentDateTime"] = DateTime.Now.ToString();
                return true;
            });
		}
	}
}