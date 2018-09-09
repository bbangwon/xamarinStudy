using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.FormsBook.Platform;

namespace TextFileAsync
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TextFileAsyncPage : ContentPage
	{
        FileHelper fileHelper = new FileHelper();

		public TextFileAsyncPage ()
		{
			InitializeComponent ();

            RefreshListView();
		}

        async void RefreshListView()
        {
            fileListView.ItemsSource = await fileHelper.GetFilesAsync();
            fileListView.SelectedItem = null;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            saveButton.IsEnabled = false;
            string filename = filenameEntry.Text;

            if(await fileHelper.ExistsAsync(filename))
            {
                bool okResponse = await DisplayAlert("TextFileTryout", "File " + filename + " already exists. Replace it?", "Yes", "No");

                if (!okResponse)
                    return;
            }

            string errorMessage = null;

            try
            {
                await fileHelper.WriteTextAsync(filenameEntry.Text, fileEditor.Text);
            }
            catch (Exception exc)
            {
                errorMessage = exc.Message;
            }

            if(errorMessage == null)
            {
                filenameEntry.Text = "";
                fileEditor.Text = "";
                RefreshListView();
            }
            else
            {
                await DisplayAlert("TextFileTryout", errorMessage, "OK");
            }

            saveButton.IsEnabled = true;
        }

        async void OnFileListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            string filename = (string)e.SelectedItem;
            string errorMessage = null;

            try
            {
                fileEditor.Text = await fileHelper.ReadTextAsync((string)e.SelectedItem);
                filenameEntry.Text = filename;
            }
            catch (Exception exc)
            {
                errorMessage = exc.Message;               
            }

            if (errorMessage != null)
            {
                await DisplayAlert("TextFileTryout", errorMessage, "OK");
            }
        }

        async void OnDeleteMenuItemClicked(object sender, EventArgs e)
        {
            string filename = (string)((MenuItem)sender).BindingContext;
            await fileHelper.DeleteAsync(filename);
            RefreshListView();
        }
    }
}