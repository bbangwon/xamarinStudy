using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SkiaStudy
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void SKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            var surface = e.Surface;
            var canvas = surface.Canvas;
            canvas.Clear(SKColors.White);

            /*

            var circleFill = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Fill,
                Color = SKColors.Blue
            };

            canvas.DrawCircle(100, 100, 40, circleFill);

            var circleBorder = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Red,
                StrokeWidth = 5
            };

            canvas.DrawCircle(100, 100, 40, circleBorder);

            var pathStroke = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Green,
                StrokeWidth = 5
            };

            var path = new SKPath();
            path.MoveTo(160, 60);
            path.LineTo(240, 140);
            path.MoveTo(240, 60);
            path.LineTo(160, 140);

            canvas.DrawPath(path, pathStroke);

            var textPaint = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Fill,
                Color = SKColors.Orange,
                TextSize = 80
            };

            canvas.DrawText("Skiasharp", 60, 160 + 80, textPaint);
            */

            using (SKPaint textPaint = new SKPaint())
            {
                textPaint.Style = SKPaintStyle.Fill;
                textPaint.TextSize = e.Info.Width / 6;
                textPaint.IsAntialias = true;

                string text = "shadow";
                float xText = 20;
                float yText = e.Info.Height / 2;

                textPaint.Color = SKColors.Gray;
                canvas.Save();
                canvas.Translate(xText, yText);
                canvas.Skew((float)Math.Tan(-Math.PI / 4), 0);
                canvas.Scale(1, 3);
                canvas.Translate(-xText, -yText);
                canvas.DrawText(text, xText, yText, textPaint);
                canvas.Restore();

                textPaint.Color = SKColors.Blue;
                canvas.DrawText(text, xText, yText, textPaint);
            }

        }
    }
}
