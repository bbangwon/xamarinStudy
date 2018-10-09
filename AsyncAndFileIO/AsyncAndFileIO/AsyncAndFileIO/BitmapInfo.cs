using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncAndFileIO
{
    class BitmapInfo
    {
        public BitmapInfo(int pixelWidth, int pixelHeight, int[] iterationCounts)
        {
            PixelWidth = pixelWidth;
            PixelHeight = pixelHeight;
            IterationCounts = iterationCounts;
        }

        public int PixelWidth { get; private set; }
        public int PixelHeight { get; private set; }
        public int[] IterationCounts { get; private set; }
    }
}
