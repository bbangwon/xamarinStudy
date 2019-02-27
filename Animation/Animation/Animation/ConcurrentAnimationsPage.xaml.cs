using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Animation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConcurrentAnimationsPage : ContentPage
    {
        public ConcurrentAnimationsPage()
        {
            InitializeComponent();
        }

        private void OnButton1Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Xamarin.Forms.Animation animation = new Xamarin.Forms.Animation(
                (double value) =>
                {
                    button.Scale = value;
                }, 1, 5, Easing.Linear, () =>
                {
                    Debug.WriteLine("finished");
                }
                );

            animation.Commit(this, "Animation1", 16, 1000,
                Easing.Linear, (double finalValue, bool wasCancelled) =>
                {
                    Debug.WriteLine("finished: {0} {1}", finalValue, wasCancelled); ;
                    button.Scale = 1;
                },
                () =>
                {
                    Debug.WriteLine("repeat");
                    return false;
                });

        }

        private void OnButton2Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Xamarin.Forms.Animation animation = new Xamarin.Forms.Animation(
                v => button.Scale = v, 1, 5);

            animation.Commit(this, "Animation2", 16, 1000, Easing.Linear, (v, c) => button.Scale = 1, () => true);


        }

        private void OnStop2Clicked(object sender, EventArgs e)
        {
            this.AbortAnimation("Animation2");
        }

        private void OnButton3Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Xamarin.Forms.Animation parentAnimation = new Xamarin.Forms.Animation();

            Xamarin.Forms.Animation upAnimation = new Xamarin.Forms.Animation(v => button.Scale = v, 1, 5, Easing.SpringIn, () => Debug.WriteLine("up finished"));

            parentAnimation.Add(0, 0.5, upAnimation);

            Xamarin.Forms.Animation downAnimation = new Xamarin.Forms.Animation(v => button.Scale = v, 5, 1, Easing.SpringOut, () => Debug.WriteLine("down finished"));

            parentAnimation.Insert(0.5, 1, downAnimation);

            parentAnimation.Commit(this, "Animation3", 16, 5000, null, (v, c) => Debug.WriteLine("parent finished: {0} {1}", v, c));
           
        }

        private void OnButton4Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            new Xamarin.Forms.Animation
            {
                { 0, 0.5, new Xamarin.Forms.Animation(v => button.Scale = v, 1, 5) },
                { 0.25, 0.75, new Xamarin.Forms.Animation(v =>button.Rotation = v, 0, 360)},
                { 0.5, 1, new Xamarin.Forms.Animation(v => button.Scale = v, 5, 1)}
            }.Commit(this, "Animation4", 16, 5000);
        }

        private void OnButton5Clicked(object sender, EventArgs e)
        {
            
        }

        private void OnTurnOffButtonClicked(object sender, EventArgs e)
        {

        }

        private void OnButton6Clicked(object sender, EventArgs e)
        {

        }
    }
}