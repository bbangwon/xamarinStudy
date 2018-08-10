using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace CollectionViews
{
    public class RssItemViewModel
    {
        public RssItemViewModel(XElement element)
        {
            Title = element.Element(XName.Get("title")).Value;
            Description = element.Element(XName.Get("description")).Value;
            Link = element.Element(XName.Get("link")).Value;
            PubDate = element.Element(XName.Get("pubDate")).Value;

            XElement thumbnailElement = element.Element(XName.Get("thumbnail", "http://search.yahoo.com/mrss/"));

            if(thumbnailElement != null)
            {
                Thumbnail = thumbnailElement.Attribute(XName.Get("url")).Value;
            }
        }

        public string Title { protected set; get; }
        public string Description { protected set; get; }
        public string Link { protected set; get; }
        public string PubDate { protected set; get; }
        public string Thumbnail { protected set; get; }
    }
}
