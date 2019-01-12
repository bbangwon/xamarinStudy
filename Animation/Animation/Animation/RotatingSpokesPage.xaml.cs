using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Animation
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RotatingSpokesPage : ContentPage
	{
        const int numSpokes = 24;
        BoxView[] boxViews = new BoxView[numSpokes];

		public RotatingSpokesPage ()
		{
			InitializeComponent ();

            for (int i = 0; i < numSpokes; i++)
            {
                BoxView boxView = new BoxView
                {
                    Color = Color.Black
                };
                boxViews[i] = boxView;
                absoluteLayout.Children.Add(boxView);
            }

            AnimationLoop();
		}

        async private void AnimationLoop()
        {
            await Task.Delay(3000);

            uint count = 3;
            await absoluteLayout.RotateTo(360 * count, 3000 * count);

            List<Task<bool>> taskList = new List<Task<bool>>(numSpokes + 1);

            while (true)
            {
                foreach(BoxView boxView in boxViews)
                {
                    taskList.Add(boxView.RelRotateTo(360, 3000));
                }

                taskList.Add(absoluteLayout.RelRotateTo(360, 3000));

                await Task.WhenAll(taskList);
                taskList.Clear();
            }
        }

        private void OnPageSizeChanged(object sender, EventArgs e)
        {
            double dimension = Math.Min(Width, Height);
            absoluteLayout.WidthRequest = dimension;
            absoluteLayout.HeightRequest = dimension;

            Point center = new Point(dimension / 2, dimension / 2);
            Size boxViewSize = new Size(dimension / 2, 3);

            for (int i = 0; i < numSpokes; i++)
            {
                double degrees = i * 360 / numSpokes;
                double radians = Math.PI * degrees / 180;

                Point boxViewCenter = new Point(
                    center.X + boxViewSize.Width / 2 * Math.Cos(radians),
                    center.Y + boxViewSize.Width / 2 * Math.Sin(radians));

                Point boxViewOrigin = boxViewCenter - boxViewSize * 0.5;
                AbsoluteLayout.SetLayoutBounds(boxViews[i], new Rectangle(boxViewOrigin, boxViewSize));

                boxViews[i].Rotation = degrees;
            }
        }
    }
}