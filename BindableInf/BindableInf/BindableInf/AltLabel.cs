using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BindableInf
{
    class AltLabel : Label
    {
        public static readonly BindableProperty PointSizeProperty =
            BindableProperty.Create("PointSize", typeof(double), typeof(AltLabel), 8.0, propertyChanged: OnPointSizeChanged);

        public AltLabel()
        {
            SetLabelFontSize((double)PointSizeProperty.DefaultValue);
        }

        public double PointSize
        {
            set { SetValue(PointSizeProperty, value); }
            get { return (double)GetValue(PointSizeProperty); }
        }

        static void OnPointSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((AltLabel)bindable).OnPointSizeChanged((double)oldValue, (double)newValue);
        }

        void OnPointSizeChanged(double oldValue, double newValue)
        {
            SetLabelFontSize(newValue);
        }

        void SetLabelFontSize(double pointSize)
        {
            FontSize = 160 * pointSize / 72;
        }
    }
}
