using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollectionViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EntryFormPage : ContentPage
	{
		public EntryFormPage ()
		{
			InitializeComponent ();
		}

        private void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            PersonalInformation personalInfo = (PersonalInformation)tableView.BindingContext;

            summaryLabel.Text = String.Format("{0} is {1} years old, and has email address of {2}, and a phone number of {3}, and is {4} a programmer",
                personalInfo.Name, personalInfo.Age,
                personalInfo.EmailAddress, personalInfo.PhoneNumber,
                personalInfo.IsProgrammer ? "" : "not ");
        }
    }
}