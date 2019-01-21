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
    public partial class BouncingBoxPage : ContentPage
    {
        static readonly uint arcDuration = 1000;
        static readonly uint bounceDuration = 250;
        static readonly double boxSize = 50;
        double layoutSize;
        bool animationGoing;

        public BouncingBoxPage()
        {
            InitializeComponent();
        }

        private void OnContentViewSizeChanged(object sender, EventArgs e)
        {
            ContentView contentView = (ContentView)sender;
            double size = Math.Min(contentView.Width, contentView.Height);
            frame.WidthRequest = size;
            frame.HeightRequest = size;
        }

        private void OnAbsoluteLayoutSizeChanged(object sender, EventArgs e)
        {
            AbsoluteLayout absoluteLayout = (AbsoluteLayout)sender;
            layoutSize = Math.Min(absoluteLayout.Width, absoluteLayout.Height);

            if(!animationGoing && layoutSize > 100)
            {
                animationGoing = true;
                animationLoop();
            }
        }

        async private void animationLoop()
        {
            while (true)
            {
                AbsoluteLayout.SetLayoutBounds(boxView, new Rectangle((layoutSize - boxSize) / 2, 0, boxSize, boxSize));

                boxView.AnchorX = layoutSize / 2 / boxSize;
                boxView.AnchorY = 0.5;
                await boxView.RotateTo(-90, arcDuration);

                Rectangle rectNormal = new Rectangle(layoutSize - boxSize,
                        (layoutSize - boxSize) / 2, boxSize, boxSize);

                Rectangle rectSquashed = new Rectangle(rectNormal.X + boxSize / 2,
                    rectNormal.Y - boxSize / 2, boxSize / 2, 2 * boxSize);

                boxView.BatchBegin();
                boxView.Rotation = 0;
                boxView.AnchorX = 0.5;
                boxView.AnchorY = 0.5;
                AbsoluteLayout.SetLayoutBounds(boxView, rectNormal);
                boxView.BatchCommit();

                await boxView.LayoutTo(rectSquashed, bounceDuration, Easing.SinOut);
                await boxView.LayoutTo(rectNormal, bounceDuration, Easing.SinIn);

                boxView.AnchorX = 0.5;
                boxView.AnchorY = layoutSize / 2 / boxSize;
                await boxView.RotateTo(-90, arcDuration);
                
                rectNormal = new Rectangle((layoutSize - boxSize) / 2,
                    layoutSize - boxSize, boxSize, boxSize);

                rectSquashed = new Rectangle(rectNormal.X - boxSize / 2, rectNormal.Y + boxSize / 2, 2 * boxSize, boxSize / 2);

                boxView.BatchBegin();
                boxView.Rotation = 0;
                boxView.AnchorX = 0.5;
                boxView.AnchorY = 0.5;
                AbsoluteLayout.SetLayoutBounds(boxView, rectNormal);
                boxView.BatchCommit();

                await boxView.LayoutTo(rectSquashed, bounceDuration, Easing.SinOut);
                await boxView.LayoutTo(rectNormal, bounceDuration, Easing.SinIn);

                boxView.AnchorX = 1 - layoutSize / 2 / boxSize;
                boxView.AnchorY = 0.5;
                await boxView.RotateTo(-90, arcDuration);

                rectNormal = new Rectangle(0, (layoutSize - boxSize) / 2, boxSize, boxSize);
                rectSquashed = new Rectangle(rectNormal.X, rectNormal.Y - boxSize / 2, boxSize / 2, 2 * boxSize);

                boxView.BatchBegin();
                boxView.Rotation = 0;
                boxView.AnchorX = 0.5;
                boxView.AnchorY = 0.5;
                AbsoluteLayout.SetLayoutBounds(boxView, rectNormal);
                boxView.BatchCommit();

                await boxView.LayoutTo(rectSquashed, bounceDuration, Easing.SinOut);
                await boxView.LayoutTo(rectNormal, bounceDuration, Easing.SinIn);

                boxView.AnchorX = 0.5;
                boxView.AnchorY = 1 - layoutSize / 2 / boxSize;
                await boxView.RotateTo(-90, arcDuration);

                rectNormal = new Rectangle((layoutSize - boxSize) / 2, 0, boxSize, boxSize);
                rectSquashed = new Rectangle(rectNormal.X - boxSize / 2, 0, 2 * boxSize, boxSize / 2);

                boxView.BatchBegin();
                boxView.Rotation = 0;
                boxView.AnchorX = 0.5;
                boxView.AnchorY = 0.5;
                AbsoluteLayout.SetLayoutBounds(boxView, rectNormal);
                boxView.BatchCommit();

                await boxView.LayoutTo(rectSquashed, bounceDuration, Easing.SinOut);
                await boxView.LayoutTo(rectNormal, bounceDuration, Easing.SinIn);
            }
        }
    }
}