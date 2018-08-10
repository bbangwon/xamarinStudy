using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Input;
using System.Xml.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Toolkit;

namespace CollectionViews
{
    public class RssFeedViewModel : ViewModelBase
    {
        string url, title;
        IList<RssItemViewModel> items;
        bool isRefreshing = true;

        public RssFeedViewModel()
        {
            RefreshCommand = new Command(
                execute: () =>
                {
                    LoadRssFeed(url);
                },
                canExecute: () =>
                {
                    return !isRefreshing;
                });
        }

        public string Url
        {
            set
            {
                if(SetProperty(ref url, value) && !string.IsNullOrEmpty(url))
                {
                    LoadRssFeed(url);
                }
            }
            get
            {
                return url;
            }                
        }
        public string Title
        {
            set { SetProperty(ref title, value); }
            get { return title; }
        }

        public IList<RssItemViewModel> Items
        {
            set { SetProperty(ref items, value); }
            get { return items; }
        }

        public ICommand RefreshCommand { private set; get; }

        public bool IsRefreshing
        {
            set { SetProperty(ref isRefreshing, value); }
            get { return isRefreshing; }
        }

        public void LoadRssFeed(string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.BeginGetResponse((args) =>
            {
                Stream stream = request.EndGetResponse(args).GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string xml = reader.ReadToEnd();

                XDocument doc = XDocument.Parse(xml);
                XElement rss = doc.Element(XName.Get("rss"));
                XElement channel = rss.Element(XName.Get("channel"));

                Title = channel.Element(XName.Get("title")).Value;

                List<RssItemViewModel> list = channel.Elements(XName.Get("item")).Select((XElement element) =>
                {
                    return new RssItemViewModel(element);
                }).ToList();

                Items = list;
                IsRefreshing = false;              
            }, null);
        }
    }
}
