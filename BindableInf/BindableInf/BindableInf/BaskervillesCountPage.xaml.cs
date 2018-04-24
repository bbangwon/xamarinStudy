using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BindableInf
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BaskervillesCountPage : ContentPage
	{
		public BaskervillesCountPage ()
		{
			InitializeComponent ();

            int wordCount = countedLabel.WordCount;
            wordCountLabel.Text = wordCount + " words";
		}
	}
}