using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Toolkit;
using Xamarin.Forms.Xaml;

namespace AsyncAndFileIO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MandelbrotCancellationPage : ContentPage
    {
        static readonly Complex center = new Complex(-0.75, 0);
        static readonly Size size = new Size(2.5, 2.5);
        const int pixelWidth = 1000;
        const int pixelHeight = 1000;
        const int iterations = 100;

        Progress<double> progressReporter;
        CancellationTokenSource cancelTokenSource;

        public MandelbrotCancellationPage()
        {
            InitializeComponent();

            progressReporter = new Progress<double>((double value) =>
            {
                progressBar.Progress = value;
            });
        }

        async void OnCalculateButtonClicked(object sender, EventArgs e)
        {
            calculateButton.IsEnabled = false;
            cancelButton.IsEnabled = true;

            cancelTokenSource = new CancellationTokenSource();

            try
            {
                BmpMaker bmpMaker = await CalculateMandelbrotAsync(progressReporter, cancelTokenSource.Token);

                image.Source = bmpMaker.Generate();
            }
            catch(OperationCanceledException)
            {
                calculateButton.IsEnabled = true;
                progressBar.Progress = 0;
            }
            catch(Exception)
            {

            }

            cancelButton.IsEnabled = false;
        }

        void OnCancelButtonClicked(object sender, EventArgs e)
        {
            cancelTokenSource.Cancel();
        }

        Task<BmpMaker> CalculateMandelbrotAsync(IProgress<double> progress, CancellationToken cancelToken)
        {
            return Task.Run<BmpMaker>(() =>
            {
                BmpMaker bmpMaker = new BmpMaker(pixelWidth, pixelHeight);

                for (int row = 0; row < pixelHeight; row++)
                {
                    double y = center.Imaginary - size.Height / 2 + row * size.Height / pixelHeight;

                    progress.Report((double)row / pixelHeight);

                    cancelToken.ThrowIfCancellationRequested();

                    for (int col = 0; col < pixelWidth; col++)
                    {
                        double x = center.Real - size.Width / 2 + col * size.Width / pixelWidth;
                        Complex c = new Complex(x, y);
                        Complex z = 0;
                        int iteration = 0;
                        bool isMandelbrotSet = false;

                        if((c - new Complex(-1, 0)).MagnitudeSquared < 1.0 / 16)
                        {
                            isMandelbrotSet = true;
                        }
                        else if(c.MagnitudeSquared * (8 * c.MagnitudeSquared - 3) < 3.0 / 32 - c.Real)
                        {
                            isMandelbrotSet = true;
                        }
                        else
                        {
                            do
                            {
                                z = z * z + c;
                                iteration++;
                            } while (iteration < iterations && z.MagnitudeSquared < 4);

                            isMandelbrotSet = iteration == iterations;
                        }
                        bmpMaker.SetPixel(row, col, isMandelbrotSet ? Color.Black : Color.White);
                    }
                }
                return bmpMaker;
            }, cancelToken);
        }
    }
}