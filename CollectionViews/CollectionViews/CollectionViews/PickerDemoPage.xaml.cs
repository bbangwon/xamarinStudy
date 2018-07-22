using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollectionViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PickerDemoPage : ContentPage
	{
		public PickerDemoPage ()
		{
			InitializeComponent ();
		}

        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            if (entry == null)
                return;

            Picker picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex == -1)
                return;

            string selectedItem = picker.Items[selectedIndex];
            PropertyInfo propertyInfo = typeof(Keyboard).GetRuntimeProperty(selectedItem);
            entry.Keyboard = (Keyboard)propertyInfo.GetValue(null);

        }
    }
}