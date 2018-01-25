﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Greetings
{
	public class VariableFormattedParagraphPage : ContentPage
	{
        
		public VariableFormattedParagraphPage ()
		{
            Content = new Label
            {
                FormattedText = new FormattedString
                {
                    Spans =
                    {
                        new Span
                        {
                            Text = "\u2003There was nothing so "
                        },
                        new Span
                        {
                            Text = "very",
                            FontAttributes = FontAttributes.Italic
                        },
                        new Span
                        {
                            Text = " much out of the way to hear the " +
                                    "Rabbit say to itself \u201cOh " +
                                    "dear! Oh dear! I shall be too late!" +
                                    "\u201d (when she thought it over " +
                                    "afterwards, it occurred to her that " +
                                    "she ought to have wondered at this, " +
                                    "but at the time it all seemed quite " +
                                    "natual); but, when the Rabbit actually "
                        },
                        new Span
                        {
                            Text = "took a watch out of its waistcoat-pocket",
                            FontAttributes = FontAttributes.Italic
                        },
                        new Span
                        {
                            Text = ", and looked at it, and then hurried on, " +
                                    "Alice started to her feet, for it flashed " +
                                    "across her mind that she had never before " +
                                    "seen a rabbit with either a waiscoat-" +
                                    "pocket, or a watch to take out of it, " +
                                    "and, burning with curiosity, she ran " +
                                    "across the field after it, and was just " +
                                    "in time to see it pop down a large " +
                                    "rabbit-hold under the hedge."
                        }
                    }
                },
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
		}
	}
}