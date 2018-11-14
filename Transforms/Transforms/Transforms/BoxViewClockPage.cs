using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Transforms
{
	public class BoxViewClockPage : ContentPage
	{
        const int COUNT = 64;
        const double THICKNESS = 4;

		public BoxViewClockPage ()
		{
            AbsoluteLayout absoluteLayout = new AbsoluteLayout();
            Content = absoluteLayout;

            for (int index = 0; index < COUNT; index++)
            {
                absoluteLayout.Children.Add(new BoxView
                {
                    Color = Color.Accent
                });
            }

            absoluteLayout.SizeChanged += (sender, args) =>
            {
                Point center = new Point(absoluteLayout.Width / 2, absoluteLayout.Height / 2);
                double radius = Math.Min(absoluteLayout.Width, absoluteLayout.Height) / 2;
                double circumference = 2 * Math.PI * radius;
                double length = circumference / COUNT;

                for (int index = 0; index < absoluteLayout.Children.Count; index++)
                {
                    BoxView boxView = (BoxView)absoluteLayout.Children[index];

                    double radians = index * 2 * Math.PI / COUNT;
                    double x = center.X + (radius - THICKNESS / 2) * Math.Sin(radians);
                    double y = center.Y - (radius - THICKNESS / 2) * Math.Cos(radians);

                    AbsoluteLayout.SetLayoutBounds(boxView, new Rectangle(x - length / 2, y - THICKNESS / 2, length, THICKNESS));

                    /*
                    AbsoluteLayout.SetLayoutBounds(boxView, 
                        new Rectangle(center.X - length / 2, center.Y - radius, length, THICKNESS));

                    boxView.AnchorX = 0.5;
                    boxView.AnchorY = radius / THICKNESS;
                    */          

                    boxView.Rotation = index * 360.0 / COUNT;
                }
            };
		}
	}
}