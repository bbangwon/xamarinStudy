﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Toolkit
{
    public class ThresholdToObjectConverter<T> : IValueConverter
    {
        public T TrueObject { set; get; }
        public T FalseObject { set; get; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double number = (double)value;
            string arg = parameter as string;
            char op = arg[0];
            double criterion = Double.Parse(arg.Substring(1).Trim());

            switch(op)
            {
                case '<': return number < criterion ? TrueObject : FalseObject;
                case '>': return number > criterion ? TrueObject : FalseObject;
                case '=': return number == criterion ? TrueObject : FalseObject;
            }
            return FalseObject;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }
    }
}
