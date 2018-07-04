using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.FormsBook.Toolkit
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewCheckBox : ContentView
	{
        public event EventHandler<bool> CheckedChanged;

		public NewCheckBox ()
		{
			InitializeComponent ();
		}

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(
                "Text",
                typeof(string),
                typeof(NewCheckBox),
                null);

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value); 
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(
                "TextColor",
                typeof(Color),
                typeof(NewCheckBox),
                Color.Default);

        public Color TextColor {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(
                "FontSize",
                typeof(double),
                typeof(NewCheckBox),
                Device.GetNamedSize(NamedSize.Default, typeof(Label)));

        [TypeConverter(typeof(FontSizeConverter))]
        public double FontSize
        {
            set => SetValue(FontSizeProperty, value);
            get => (double)GetValue(FontSizeProperty);
        }

        public static readonly BindableProperty FontAttributesProperty =
            BindableProperty.Create(
                "FontAttributes",
                typeof(FontAttributes),
                typeof(NewCheckBox),
                FontAttributes.None);

        public FontAttributes FontAttributes
        {
            set => SetValue(FontAttributesProperty, value);
            get => (FontAttributes)GetValue(FontAttributesProperty);
        }

        public static readonly BindableProperty IsCheckedProperty =
            BindableProperty.Create(
                "IsChecked",
                typeof(bool),
                typeof(NewCheckBox),
                false,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    NewCheckBox checkbox = (NewCheckBox)bindable;
                    checkbox.CheckedChanged?.Invoke(checkbox, (bool)newValue);
                });

        public bool IsChecked
        {
            set => SetValue(IsCheckedProperty, value);
            get => (bool)GetValue(IsCheckedProperty);
        }

        void OnCheckBoxTapped(object sender, EventArgs args)
        {
            IsChecked = !IsChecked;
        }
    }
}