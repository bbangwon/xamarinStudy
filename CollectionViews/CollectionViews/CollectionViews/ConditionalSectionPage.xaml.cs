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
	public partial class ConditionalSectionPage : ContentPage
	{
		public ConditionalSectionPage()
		{
			InitializeComponent ();

            ProgrammerInformation programmerInfo = new ProgrammerInformation();
            tableView.BindingContext = programmerInfo;

            tableView.Root.Remove(programmerInfoSection);

            programmerInfo.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "IsProgrammer")
                {
                    if (programmerInfo.IsProgrammer && tableView.Root.IndexOf(programmerInfoSection) == -1)
                    {
                        tableView.Root.Add(programmerInfoSection);
                    }
                    if (!programmerInfo.IsProgrammer && tableView.Root.IndexOf(programmerInfoSection) != -1)
                    {
                        tableView.Root.Remove(programmerInfoSection);
                    }
                }
            };
		}
	}
}