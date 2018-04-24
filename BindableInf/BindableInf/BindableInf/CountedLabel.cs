using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;

namespace BindableInf
{
    public class CountedLabel : Label
    {
        static readonly BindablePropertyKey WordCountKey =
            BindableProperty.CreateReadOnly("WordCount", typeof(int), typeof(CountedLabel), 0);

        public static readonly BindableProperty WordCountProperty = WordCountKey.BindableProperty;

        public int WordCount
        {
            private set { SetValue(WordCountKey, value); }
            get { return (int)GetValue(WordCountProperty); }
        }

        public CountedLabel()
        {
            PropertyChanged += (object sender, PropertyChangedEventArgs args) =>
            {
                if(args.PropertyName == "Text")
                {
                    if(string.IsNullOrEmpty(Text))
                    {
                        WordCount = 0;
                    }
                    else
                    {
                        WordCount = Text.Split(' ', '-', '\u2014').Length;
                    }
                }
            };
        }
    }
}
