using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Styles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DeviceStylesListPage : ContentPage
	{
		public DeviceStylesListPage ()
		{
			InitializeComponent ();

            var styleItems = new[]
            {
                new { style = (Style)null, name = "No style whatsoever" },
                new { style = Device.Styles.BodyStyle, name = "Body Style"},
                new { style = Device.Styles.TitleStyle, name = "Title Style"},
                new { style = Device.Styles.SubtitleStyle, name = "Subtitle Style"},
                new { style = new Style(typeof(Label))
                {
                    BaseResourceKey = Device.Styles.SubtitleStyleKey,
                    Setters =
                    {
                        new Setter
                        {
                            Property = Label.TextColorProperty,
                            Value = Color.Accent
                        },
                        new Setter
                        {
                            Property = Label.FontAttributesProperty,
                            Value = FontAttributes.Italic
                        }
                    }
                }, name="New Subtitle Style"},
                new {style = Device.Styles.CaptionStyle, name="Caption Style"},
                new {style = Device.Styles.ListItemTextStyle, name="List Item Text Style"},
                new {style = Device.Styles.ListItemDetailTextStyle, name= "List Item Detail Text Style"},
            };

            foreach(var styleItem in styleItems)
            {
                codeLabelStack.Children.Add(new Label
                {
                    Text = styleItem.name,
                    Style = styleItem.style
                });
            }
		}
	}
}