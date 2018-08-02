using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Toolkit
{
    public class NamedColor
    {
        private NamedColor()
        {

        }

        public string Name { private set; get;  }
        public string FriendlyName { private set; get; }
        public Color Color { private set; get; }
        public string RgbDisplay { private set; get; }

        static NamedColor()
        {
            List<NamedColor> all = new List<NamedColor>();
            StringBuilder stringBuilder = new StringBuilder();

            foreach (FieldInfo fieldInfo in typeof(NamedColor).GetRuntimeFields())
            {
                if(fieldInfo.IsPublic && 
                   fieldInfo.IsStatic &&
                   fieldInfo.FieldType == typeof(Color))
                {
                    string name = fieldInfo.Name;
                    stringBuilder.Clear();
                    int index = 0;

                    foreach (char ch in name)
                    {
                        if(index != 0 && Char.IsUpper(ch))
                        {
                            stringBuilder.Append(' ');
                        }
                        stringBuilder.Append(ch);
                        index++;
                    }

                    Color color = (Color)fieldInfo.GetValue(null);
                    NamedColor namedColor = new NamedColor
                    {
                        Name = name,
                        FriendlyName = stringBuilder.ToString(),
                        Color = color,
                        RgbDisplay = String.Format("{0:X2}-{1:X2}-{2:X2}",
                                        (int)(255 * color.R),
                                        (int)(255 * color.G),
                                        (int)(255 * color.B))
                    };

                    all.Add(namedColor);
                }
            }

            all.TrimExcess();
            All = all;
        }

        public override string ToString()
        {
            return FriendlyName;
        }
        public static IList<NamedColor> All { private set; get; }

        public static readonly Color AliceBlue = Color.FromRgb(240, 248, 255);
        public static readonly Color AntiqueWhite = Color.FromRgb(250, 235, 215);
        public static readonly Color Aqua = Color.FromRgb(0, 255, 255);
        public static readonly Color AquaMarine = Color.FromRgb(127, 255, 212);
        public static readonly Color Azure = Color.FromRgb(240, 255, 255);
        public static readonly Color Beige = Color.FromRgb(245, 245, 220);
        public static readonly Color Bisque = Color.FromRgb(255, 228, 196);
        public static readonly Color Black = Color.FromRgb(0, 0, 0);
        public static readonly Color BlanchedImond = Color.FromRgb(255, 235, 205);
        public static readonly Color Blue = Color.FromRgb(0, 0, 255);
        public static readonly Color BlueViolet = Color.FromRgb(138, 43, 226);
        public static readonly Color Brown = Color.FromRgb(165, 42, 42);
        public static readonly Color Burlywood = Color.FromRgb(222, 184, 135);
        public static readonly Color CadetBlue = Color.FromRgb(95, 158, 160);
        public static readonly Color Charteuse = Color.FromRgb(127, 255, 0);
        public static readonly Color Chocolate = Color.FromRgb(210, 105, 30);
        public static readonly Color Coral = Color.FromRgb(255, 127, 80);
        public static readonly Color CornFlowerBlue = Color.FromRgb(100, 149, 237);
        public static readonly Color Cornsilk = Color.FromRgb(255, 248, 220);
        public static readonly Color Crimson = Color.FromRgb(220, 20, 60);
        public static readonly Color Cyan = Color.FromRgb(0, 255, 255);
        public static readonly Color DarkBlue = Color.FromRgb(0, 0, 139);
        public static readonly Color DarkCyan = Color.FromRgb(0, 139, 139);
        public static readonly Color DarkGoldenRod = Color.FromRgb(184, 134, 11);
        public static readonly Color DarkGray = Color.FromRgb(169, 169, 169);
        public static readonly Color DarkGreen = Color.FromRgb(0, 100, 0);
        public static readonly Color DarkKhaki = Color.FromRgb(189, 183, 107);
        public static readonly Color DarkMagenta = Color.FromRgb(139, 0, 139);
        public static readonly Color DarkOliveGreen = Color.FromRgb(85, 107, 47);
        public static readonly Color DarkOrange = Color.FromRgb(255, 140, 0);
        public static readonly Color Darkorchid = Color.FromRgb(153, 50, 204);
        public static readonly Color DarkRed = Color.FromRgb(139, 0, 0);

    }
}
