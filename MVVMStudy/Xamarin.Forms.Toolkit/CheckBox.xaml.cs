﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.Toolkit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckBox : ContentView
    {
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(CheckBox), null, propertyChanged: (bindable, oldValue, newValue) =>
            {
                ((CheckBox)bindable).textLabel.Text = (string)newValue;
            });

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create("FontSize", typeof(double), typeof(CheckBox), Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    CheckBox checkbox = (CheckBox)bindable;
                    checkbox.boxLabel.FontSize = (double)newValue;
                    checkbox.textLabel.FontSize = (double)newValue;
                });

        public static readonly BindableProperty IsCheckedProperty =
            BindableProperty.Create("IsChecked", typeof(bool), typeof(CheckBox), false, propertyChanged: (bindable, oldValue, newValue) =>
            {
                CheckBox checkbox = (CheckBox)bindable;
                checkbox.boxLabel.Text = (bool)newValue ? "\u2611" : "\u2610";
                checkbox.CheckedChanged?.Invoke(checkbox, (bool)newValue);
            });

        public event EventHandler<bool> CheckedChanged;

        public CheckBox()
        {
            InitializeComponent();
        }

        public string Text
        {
            set { SetValue(TextProperty, value); }
            get { return (string)GetValue(TextProperty); }
        }

        [TypeConverter(typeof(FontSizeConverter))]
        public double FontSize
        {
            set { SetValue(FontSizeProperty, value); }
            get { return (double)GetValue(FontSizeProperty); }
        }

        public bool IsChecked
        {
            set { SetValue(IsCheckedProperty, value); }
            get { return (bool)GetValue(IsCheckedProperty); }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            IsChecked = !IsChecked;
        }
    }
}