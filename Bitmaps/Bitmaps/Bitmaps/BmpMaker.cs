﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Bitmaps
{
    class BmpMaker
    {
        const int headerSize = 54;
        readonly byte[] buffer;

        public BmpMaker(int width, int height)
        {
            Width = width;
            Height = height;

            int numPixels = width * height;
            int numPixelBytes = 4 * numPixels;
            int fileSize = headerSize + numPixelBytes;
            buffer = new byte[fileSize];

            using (MemoryStream memoryStream = new MemoryStream(buffer))
            {
                using (BinaryWriter writer = new BinaryWriter(memoryStream, Encoding.UTF8))
                {
                    writer.Write(new char[] { 'B', 'M' });  //Signature
                    writer.Write(fileSize); //FileSize
                    writer.Write((short)0); //Reserved
                    writer.Write((short)0); //Reserved
                    writer.Write(headerSize);   //Offset to pixels

                    writer.Write(40);       // Header Size
                    writer.Write(Width);    //Pixel width
                    writer.Write(Height);   //Pixel Height
                    writer.Write((short)1); //Planes
                    writer.Write((short)32); //Bits per pixel
                    writer.Write(0);        //Compression
                    writer.Write(numPixelBytes);    //Image Size in bytes
                    writer.Write(0);        //X pixels per meter
                    writer.Write(0);        //Y pixels per meter
                    writer.Write(0);        //Number colors in color table
                    writer.Write(0);        //Important color count
                }
            }
        }

        public int Width
        {
            private set;
            get;
        }

        public int Height
        {
            private set;
            get;
        }

        public void SetPixel(int row, int col, Color color)
        {
            SetPixel(row, col, (int)(255 * color.R),
                    (int)(255 * color.G),
                    (int)(255 * color.B),
                    (int)(255 * color.A)
                );
        }

        public void SetPixel(int row, int col, int r, int g, int b, int a = 255)
        {
            int index = (row * Width + col) * 4 + headerSize;
            buffer[index + 0] = (byte)b;
            buffer[index + 1] = (byte)g;
            buffer[index + 2] = (byte)r;
            buffer[index + 3] = (byte)a;
        }

        public ImageSource Generate()
        {
            MemoryStream memoryStream = new MemoryStream(buffer);
            ImageSource imageSource = ImageSource.FromStream(() =>
            {
                return memoryStream;
            });
            return imageSource;
        }

    }
}
