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



    }
}
