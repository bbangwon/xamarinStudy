using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheInteractiveInterface
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchBarDemoPage : ContentPage
	{
        const double MaxMatches = 100;
        string bookText;

		public SearchBarDemoPage ()
		{
			InitializeComponent ();
            string resourceID = "TheInteractiveInterface.Text.MobyDick.txt";
            Assembly assembly = GetType().GetTypeInfo().Assembly;

            using (Stream stream = assembly.GetManifestResourceStream(resourceID))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    bookText = reader.ReadToEnd();
                }
            }
        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            resultStack.Children.Clear();
        }

        private void searchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            resultsScroll.Content = null;
            resultStack.Children.Clear();
            SearchBookForText(searchBar.Text);

            resultsScroll.Content = resultStack;
        }

        void SearchBookForText(string searchText)
        {
            int count = 0;
            bool isTruncated = false;

            using (StringReader reader = new StringReader(bookText))
            {
                int lineNumber = 0;
                string line;

                while(null != (line = reader.ReadLine()))
                {
                    lineNumber++;
                    int index = 0;

                    while(-1 != (index = (line.IndexOf(searchText, index, StringComparison.OrdinalIgnoreCase))))
                    {
                        if(count == MaxMatches)
                        {
                            isTruncated = true;
                            break;
                        }
                        index += 1;

                        resultStack.Children.Add(
                            new Label
                            {
                                Text = String.Format("Found at line {0}, offset {1}", lineNumber, index)
                            });

                        count++;
                    }
                    if(isTruncated)
                    {
                        break;
                    }
                }
            }

            resultStack.Children.Add(
                new Label
                {
                    Text = String.Format("{0} match{1} found{2}",
                    count, count == 1? "" : "es", isTruncated?" - stopped": "")
                });
        }
    }
}