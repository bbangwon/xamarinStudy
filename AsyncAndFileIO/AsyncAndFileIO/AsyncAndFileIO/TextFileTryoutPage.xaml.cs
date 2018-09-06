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
    public partial class TextFileTryoutPage : ContentPage
    {
        FileHelper fileHelper = new FileHelper();
        public TextFileTryoutPage()
        {
            InitializeComponent();
            RefreshListView();
        }

        private void RefreshListView()
        {
            fileListView.ItemsSource = fileHelper.GetFiles();
            fileListView.SelectedItem = null;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            string filename = filenameEntry.Text;
            if(fileHelper.Exists(filename))
            {
                bool okResponse = await DisplayAlert("TextFileTryout", "File " + filename + " already exists. Replace it?", "Yes", "No");

                if (!okResponse)
                    return;
            }

            string errorMessage = null;
            try
            {
                fileHelper.WriteText(filenameEntry.Text, fileEditor.Text);
            }
            catch(Exception exc)
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
        }

        async void OnFileListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            string filename = (string)e.SelectedItem;
            string errorMessage = null;

            try
            {
                fileEditor.Text = fileHelper.ReadText((string)e.SelectedItem);
                filenameEntry.Text = filename;
            }
            catch (Exception exc)
            {
                errorMessage = exc.Message;
            }
            if(errorMessage != null)
            {
                await DisplayAlert("TextFileTryout", errorMessage, "OK");
            }
        }

        private void OnDeleteMenuItemClicked(object sender, EventArgs e)
        {
            string filename = (string)((MenuItem)sender).BindingContext;
            fileHelper.Delete(filename);
            RefreshListView();
        }

    }
}