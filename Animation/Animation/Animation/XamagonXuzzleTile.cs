using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Animation
{
    public class XamagonXuzzleTile : ContentView
    {
        public int Row { set; get; }
        public int Col { set; get; }
        public XamagonXuzzleTile(int row, int col, ImageSource imageSource)
        {
            Row = row;
            Col = col;

            Padding = new Thickness(1);
            Content = new Image
            {
                Source = imageSource
            };
        }
    }
}