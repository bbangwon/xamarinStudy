using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AsyncAndFileIO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MandelbrotXFPage : ContentPage
    {
        public MandelbrotXFPage()
        {
            InitializeComponent();
        }

        private void OnPageSizeChanged(object sender, EventArgs e)
        {

        }
    }
}