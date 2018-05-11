using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bitmaps
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImageBrowserPage : ContentPage
	{
        [DataContract]
        class ImageList
        {
            [DataMember(Name = "photos")]
            public List<string> Photos = null;
        }

        WebRequest webRequest;
        ImageList imageList;
        int imageListIndex = 0;

		public ImageBrowserPage ()
		{
			InitializeComponent ();

            Uri uri = new Uri("https://developer.xamarin.com/demo/stock.json");
            webRequest = WebRequest.Create(uri);
            webRequest.BeginGetResponse(WebRequestCallback, null);
		}

        void WebRequestCallback(IAsyncResult result)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    Stream stream = webRequest.EndGetResponse(result).GetResponseStream();

                    var jsonSerializer = new DataContractJsonSerializer(typeof(ImageList));
                    imageList = (ImageList)jsonSerializer.ReadObject(stream);

                    if (imageList.Photos.Count > 0)
                        FetchPhoto();
                }
                catch(Exception exc)
                {
                    filenameLabel.Text = exc.Message;
                }
            });
        }        

        private void image_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "IsLoading")
            {
                activityIndicator.IsRunning = ((Image)sender).IsLoading;
            }
        }

        private void prevButton_Clicked(object sender, EventArgs e)
        {
            imageListIndex--;
            FetchPhoto();
        }

        private void nextButton_Clicked(object sender, EventArgs e)
        {
            imageListIndex++;
            FetchPhoto();
        }

        void FetchPhoto()
        {
            image.Source = null;
            string url = imageList.Photos[imageListIndex];

            filenameLabel.Text = url.Substring(url.LastIndexOf('/') + 1);

            UriImageSource uriImageSource = new UriImageSource
            {
                Uri = new Uri(url + "?width=1080"),
                CacheValidity = TimeSpan.FromDays(30)
            };

            image.Source = uriImageSource;

            prevButton.IsEnabled = imageListIndex > 0;
            nextButton.IsEnabled = imageListIndex < imageList.Photos.Count - 1;
        }
    }
}