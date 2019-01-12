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
    public partial class PalindromeAnimationPage : ContentPage
    {
        string text = "NEVER ODD OR EVEN";
        double[] anchorX = {0.5, 0.5, 0.5, 0.5, 1, 0,
        0.5, 1, 1, -1,
        0.5, 1, 0,
        0.5, 0.5, 0.5, 0.5};

        public PalindromeAnimationPage()
        {
            InitializeComponent();

            for (int i = 0; i < text.Length; i++)
            {
                Label label = new Label
                {
                    Text = text[i].ToString(),
                    HorizontalTextAlignment = TextAlignment.Center
                };
                stackLayout.Children.Add(label);
            }

            AnimationLoop();
        }

        async private void AnimationLoop()
        {
            bool backwards = false;

            while (true)
            {
                await Task.Delay(1000);

                Label previousLabel = null;

                IEnumerable<Label> labels = stackLayout.Children.OfType<Label>();

                foreach (Label label in backwards ? labels.Reverse() : labels)
                {
                    uint flipTime = 250;

                    int index = stackLayout.Children.IndexOf(label);
                    label.AnchorX = anchorX[index];
                    label.AnchorY = 1;

                    if (previousLabel == null)
                    {
                        await label.RelRotateTo(90, flipTime / 2);
                    }
                    else
                    {
                        await Task.WhenAll(label.RelRotateTo(90, flipTime / 2),
                            previousLabel.RelRotateTo(90, flipTime / 2));
                    }

                    if(label == (backwards? labels.First(): labels.Last()))
                    {
                        await label.RelRotateTo(90, flipTime / 2);
                    }

                    previousLabel = label;

                }

                stackLayout.AnchorY = 1;
                await stackLayout.RelRotateTo(180, 1000);

                backwards ^= true;
            }
        }

        private void OnPageSizeChanged(object sender, EventArgs e)
        {
            double width = 0.8 * Width / stackLayout.Children.Count;

            foreach (Label label in stackLayout.Children.OfType<Label>())
            {
                label.FontSize = 1.4 * width;
                label.WidthRequest = width;
            }
        }
    }
}