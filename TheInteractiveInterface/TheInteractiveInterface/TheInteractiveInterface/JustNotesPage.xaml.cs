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
	public partial class JustNotesPage : ContentPage
	{
		public JustNotesPage ()
		{
			InitializeComponent ();

            IDictionary<string, object> properties = Application.Current.Properties;

            if(properties.ContainsKey("text"))
            {
                editor.Text = (string)properties["text"];
            }
		}

        private void editor_Focused(object sender, FocusEventArgs e)
        {
            if(Device.RuntimePlatform == Device.iOS)
            {
                AbsoluteLayout.SetLayoutBounds(editor, new Rectangle(0, 0, 1, 0.5));
            }
        }

        private void editor_Unfocused(object sender, FocusEventArgs e)
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                AbsoluteLayout.SetLayoutBounds(editor, new Rectangle(0, 0, 1, 1));
            }
        }

        public void OnSleep()
        {
            Application.Current.Properties["text"] = editor.Text;
        }
    }
}